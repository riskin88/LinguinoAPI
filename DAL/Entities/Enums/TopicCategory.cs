using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json.Serialization;

namespace DAL.Entities.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TopicCategory
    {
        MAIN,
        EXTRA
    }
}
