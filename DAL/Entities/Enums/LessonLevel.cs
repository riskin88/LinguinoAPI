using System.Text.Json.Serialization;

namespace DAL.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum LessonLevel
    {
        A1,
        A2,
        B1,
        B2,
        C1,
        C2
    }
}
