using System.Text.Json.Serialization;

namespace DAL.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SubscriptionStatus
    {
        TRIALING,
        INCOMPLETE,
        INCOMPLETE_EXPIRED,
        ACTIVE,
        PAST_DUE,
        CANCELED,
        SCHEDULED_TO_CANCEL,
        UNPAID,
        PAUSED
    }
}