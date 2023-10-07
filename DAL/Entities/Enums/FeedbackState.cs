using System.Text.Json.Serialization;

namespace DAL.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FeedbackState
    {
        UNDEFINED,
        LIKE,
        DISLIKE   
    }
}
