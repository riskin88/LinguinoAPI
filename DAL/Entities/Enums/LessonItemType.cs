using System.Text.Json.Serialization;

namespace DAL.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LessonItemType
    {
        WORD,
        GRAMMAR,
        LISTENING,
        SPEAKING,
        PRONUNCIATION,
        READING
    }
}
