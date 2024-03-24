using AutoMapper;
using BLL.Config;
using DAL.Entities.Enums;
using DAL.Entities;
using DAL.UnitOfWork;
using Microsoft.Extensions.Options;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using BLL.Services.Contracts;
using Microsoft.Extensions.Logging;
using BLL.DTO.Subscriptions;
using System.Diagnostics.Eventing.Reader;

namespace BLL.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SubscriptionSettings _configuration;

        public SubscriptionService(IUnitOfWork unitOfWork, IMapper mapper, IOptions<SubscriptionSettings> configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration.Value;
        }

        public async Task<CreateSubscriptionRespDTO> StartSubscription()
        {
            StripeConfiguration.ApiKey = _configuration.StripeApiKey;
            var user = await _unitOfWork.UserRepository.GetCurrentUserWithSubscription();
            CreateSubscriptionRespDTO responseDTO;
            if (user.Subscription == null || (user.Subscription.Status == SubscriptionStatus.INCOMPLETE_EXPIRED || user.Subscription.Status == SubscriptionStatus.CANCELED || user.Subscription.Status == SubscriptionStatus.UNPAID))
            {
                
                responseDTO = CreateNewSubscription(user);
            }

            else if (user.Subscription.Status == SubscriptionStatus.TRIALING)
            {
                responseDTO = SubscribeDuringTrial(user);
            }
            else if (user.Subscription.Status == SubscriptionStatus.PAUSED)
            {
                responseDTO = ResumeAfterTrial(user);
            }
            else
            {
                throw new SubscriptionErrorException("Oops, it seems you already have a subscription in progress.");
            }

            _unitOfWork.SaveChanges();
            return responseDTO;

        }

        public async Task StartTrial()
        {
            StripeConfiguration.ApiKey = _configuration.StripeApiKey;
            var user = await _unitOfWork.UserRepository.GetCurrentUserWithSubscription();
            if (user.Subscription != null)
            {
                throw new SubscriptionErrorException("You are not eligible for a trial period anymore.");
            }

            var customerId = CreateCustomer(user);
            user.Subscription = new DAL.Entities.Subscription { StripeCustomerId = customerId };

            var options = new SubscriptionCreateOptions
            {
                Customer = customerId,
                Items = new List<SubscriptionItemOptions> { new() { Price = _configuration.PriceId } },
                TrialPeriodDays = _configuration.TrialDays,
                TrialSettings = new() { EndBehavior = new() { MissingPaymentMethod = "pause" } },
                PaymentSettings = new(){ SaveDefaultPaymentMethod = "on_subscription" },
                PaymentBehavior = "default_incomplete"
            };

            var subscriptionService = new Stripe.SubscriptionService();
            try
            {
                var subscription = subscriptionService.Create(options);
                user.Subscription.StripeSubscriptionId = subscription.Id;
                SubscriptionStatus status;
                if (Enum.TryParse(subscription.Status.ToUpper(), out status))
                {
                    user.Subscription.Status = status;
                }

                _unitOfWork.SaveChanges();

            }
            catch (StripeException)
            {
                throw new MyBadException("Failed to create subscription.");
            }
        }

        public async Task<GetSubscriptionDTO> CancelSubscription(CancelSubscriptionDTO cancelSubscriptionDTO)
        {
            StripeConfiguration.ApiKey = _configuration.StripeApiKey;
            var service = new Stripe.SubscriptionService();
            var user = await _unitOfWork.UserRepository.GetCurrentUserWithSubscription();
            if (user.Subscription != null)
            {
                var options = new SubscriptionUpdateOptions
                {
                    CancelAtPeriodEnd = true
                    
                };
                if (cancelSubscriptionDTO.UnsubscribeReason != null)
                {

                    options.CancellationDetails = new() { Comment = cancelSubscriptionDTO.UnsubscribeReason };
                }


                


                var subscription = service.Update(user.Subscription.StripeSubscriptionId, options);
                user.Subscription.StripeSubscriptionId = subscription.Id;
                user.Subscription.Status = SubscriptionStatus.SCHEDULED_TO_CANCEL;

                _unitOfWork.SaveChanges();
                return new GetSubscriptionDTO { Status = user.Subscription.Status, CurrentPeriodEnd = subscription.CurrentPeriodEnd };
            }
            else throw new SubscriptionErrorException("You have no active subscription.");

        }

        public async Task<GetSubscriptionDTO> GetSubscription()
        {
            StripeConfiguration.ApiKey = _configuration.StripeApiKey;
            var service = new Stripe.SubscriptionService();
            var user = await _unitOfWork.UserRepository.GetCurrentUserWithSubscription();
            if (user.Subscription != null)
            {
                var subscription = service.Get(user.Subscription.StripeSubscriptionId);
                return new GetSubscriptionDTO { Status = user.Subscription.Status, CurrentPeriodEnd = subscription.CurrentPeriodEnd };
            }

            else throw new SubscriptionErrorException("You have no active subscription.");
        }


        public async Task UpdateStatus(Stripe.Subscription subscription)
        {
            var user = await _unitOfWork.UserRepository.GetUserByStripeSubscriptionId(subscription.Id);
            if (user.Subscription.Status == SubscriptionStatus.SCHEDULED_TO_CANCEL && subscription.Status != "canceled")
                return;
            SubscriptionStatus status;
            if (Enum.TryParse(subscription.Status.ToUpper(), out status))
            {
                user.Subscription.Status = status;
            }
            if (status == SubscriptionStatus.ACTIVE || status == SubscriptionStatus.TRIALING)
            {
                await _unitOfWork.UserManager.AddToRoleAsync(user, "PREMIUM_USER");
                await _unitOfWork.UserManager.RemoveFromRoleAsync(user, "USER");
            }
            else if (status == SubscriptionStatus.UNPAID || status == SubscriptionStatus.CANCELED || status == SubscriptionStatus.PAUSED)
            {
                await _unitOfWork.UserManager.RemoveFromRoleAsync(user, "PREMIUM_USER");
                await _unitOfWork.UserManager.AddToRoleAsync(user, "USER");
            }

            _unitOfWork.SaveChanges();
        }

        private CreateSubscriptionRespDTO CreateNewSubscription(User user)
        {
            var service = new Stripe.SubscriptionService();
            string customerId;
            if (user.Subscription != null)
            {
                customerId = user.Subscription.StripeCustomerId;
            }
            else
            {
                customerId = CreateCustomer(user);
            }
            user.Subscription = new DAL.Entities.Subscription { StripeCustomerId = customerId };
            var options = new SubscriptionCreateOptions
            {
                Customer = customerId,
                Items = new List<SubscriptionItemOptions> { new() { Price = _configuration.PriceId } },
                PaymentSettings = new() { SaveDefaultPaymentMethod = "on_subscription" },
                PaymentBehavior = "default_incomplete"
            };
            options.AddExpand("latest_invoice.payment_intent");
            options.AddExpand("pending_setup_intent");


            try
            {
                var subscription = service.Create(options);
                CreateSubscriptionRespDTO resp = new();
                if (subscription.PendingSetupIntent != null)
                {
                    resp = new CreateSubscriptionRespDTO
                    {
                        Type = "setup",
                        ClientSecret = subscription.PendingSetupIntent.ClientSecret,
                    };
                }
                else
                {
                    resp = new CreateSubscriptionRespDTO
                    {
                        Type = "payment",
                        ClientSecret = subscription.LatestInvoice.PaymentIntent.ClientSecret,
                    };
                }
                user.Subscription.StripeSubscriptionId = subscription.Id;
                SubscriptionStatus status;
                if (Enum.TryParse(subscription.Status.ToUpper(), out status))
                {
                    user.Subscription.Status = status;
                }
                return resp;
            }
            catch (StripeException)
            {
                throw new MyBadException("Failed to create subscription.");
            }
        }

        private CreateSubscriptionRespDTO SubscribeDuringTrial(User user)
        {
            var service = new Stripe.SubscriptionService();
            var options = new SubscriptionGetOptions
            {
            };
            options.AddExpand("latest_invoice.payment_intent");
            options.AddExpand("pending_setup_intent");
            var subscription = service.Get(user.Subscription.StripeSubscriptionId, options);
            if (subscription != null)
            {
                CreateSubscriptionRespDTO resp = new();
                if (subscription.PendingSetupIntent != null)
                {
                    resp = new CreateSubscriptionRespDTO
                    {
                        Type = "setup",
                        ClientSecret = subscription.PendingSetupIntent.ClientSecret,
                    };
                }
                user.Subscription.StripeSubscriptionId = subscription.Id;
                SubscriptionStatus status;
                if (Enum.TryParse(subscription.Status.ToUpper(), out status))
                {
                    user.Subscription.Status = status;
                }
                return resp;
            }
            else throw new MyBadException("Failed to load your trialing subscription.");
        }

        private CreateSubscriptionRespDTO ResumeAfterTrial(User user)
        {
            var service = new Stripe.SubscriptionService();
            var options = new SubscriptionResumeOptions
            {
                BillingCycleAnchor = SubscriptionBillingCycleAnchor.Now,
            };
            options.AddExpand("latest_invoice.payment_intent");
            options.AddExpand("pending_setup_intent");
            try
            {
                var subscription = service.Resume(user.Subscription.StripeSubscriptionId, options);
                if (subscription != null)
                {
                    CreateSubscriptionRespDTO resp = new();
                    if (subscription.LatestInvoice != null)
                    {
                        resp = new CreateSubscriptionRespDTO
                        {
                            Type = "payment",
                            ClientSecret = subscription.LatestInvoice.PaymentIntent.ClientSecret,
                        };
                    }
                    else if (subscription.PendingSetupIntent != null)
                    {
                        resp = new CreateSubscriptionRespDTO
                        {
                            Type = "setup",
                            ClientSecret = subscription.PendingSetupIntent.ClientSecret,
                        };
                    }
                    user.Subscription.StripeSubscriptionId = subscription.Id;
                    SubscriptionStatus status;
                    if (Enum.TryParse(subscription.Status.ToUpper(), out status))
                    {
                        user.Subscription.Status = status;
                    }
                    return resp;
                }
                else throw new MyBadException("Failed to load your trialed subscription.");
            }
            catch (StripeException)
            {
                throw new MyBadException("Failed to resume subscription.");
            }
        }


        private string CreateCustomer(User user)
        {
            var options = new CustomerCreateOptions
            {
                Email = user.Email,
                Name = user.UserName,
            };
            var service = new CustomerService();
            Customer customer = service.Create(options);
            return customer.Id;
        }
    }
}
