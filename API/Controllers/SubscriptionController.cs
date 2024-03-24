using BLL.Config;
using BLL.DTO.Subscriptions;
using BLL.DTO.Users;
using BLL.Services.Contracts;
using DAL.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;

namespace LinguinoAPI.Controllers
{
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly SubscriptionSettings _configuration;

        public SubscriptionController(ISubscriptionService subscriptionService, IOptions<SubscriptionSettings> configuration)
        {
            _subscriptionService = subscriptionService;
            _configuration = configuration.Value;
        }

        [HttpPost, Authorize]
        [Route("user/subscription/trial")]
        public async Task<ActionResult> StartTrial()
        {
            await _subscriptionService.StartTrial();
            return Ok();
        }

        [HttpPost, Authorize]
        [Route("user/subscription")]
        public async Task<ActionResult<CreateSubscriptionRespDTO>> StartSubscription()
        {
            return Ok(await _subscriptionService.StartSubscription());
        }

        [HttpDelete, Authorize]
        [Route("user/subscription")]
        public async Task<ActionResult<GetSubscriptionDTO>> CancelSubscription(CancelSubscriptionDTO cancelSubscriptionDTO)
        {
            return Ok(await _subscriptionService.CancelSubscription(cancelSubscriptionDTO));
        }

        [HttpGet, Authorize]
        [Route("user/subscription")]
        public async Task<ActionResult<GetSubscriptionDTO>> GetSubscription()
        {
            return Ok(await _subscriptionService.GetSubscription());
        }

        [HttpPost]
        [Route("stripe-webhook")]
        public async Task<IActionResult> Webhook()
        {

            StripeConfiguration.ApiKey = _configuration.StripeApiKey;
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], _configuration.WebhookSecret);

                if (stripeEvent.Type == Events.CustomerSubscriptionCreated || stripeEvent.Type == Events.CustomerSubscriptionPaused || stripeEvent.Type == Events.CustomerSubscriptionDeleted || stripeEvent.Type == Events.CustomerSubscriptionResumed)
                {
                    var subscription = stripeEvent.Data.Object as Subscription;
                    if (subscription != null)
                    {
                        await _subscriptionService.UpdateStatus(subscription);
                    }

                }
                else if (stripeEvent.Type == Events.CustomerSubscriptionUpdated)
                {
                    var subscription = stripeEvent.Data.Object as Subscription;
                    if (subscription != null && stripeEvent.Data.PreviousAttributes["status"] != "paused")
                    {
                        await _subscriptionService.UpdateStatus(subscription);
                    }

                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
