using System.Text.Json.Serialization;

namespace DAL.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LessonItemState
    {
        NEW,
        REVIEW
    }
}
