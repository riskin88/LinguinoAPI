using System.Text.Json.Serialization;

namespace DAL.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LessonType
    {
        VOCABULARY,
        GRAMMAR,
        LISTENING,
        SPEAKING,
        PRONUNCIATION,
        READING
    }
}
