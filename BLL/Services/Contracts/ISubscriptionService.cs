using BLL.DTO.Subscriptions;
using Stripe;

namespace BLL.Services.Contracts
{
    public interface ISubscriptionService
    {
        Task<GetSubscriptionDTO> CancelSubscription(CancelSubscriptionDTO cancelSubscriptionDTO);
        Task<GetSubscriptionDTO> GetSubscription();
        Task<CreateSubscriptionRespDTO> StartSubscription();
        Task StartTrial();
        Task UpdateStatus(Subscription subscription);
    }
}