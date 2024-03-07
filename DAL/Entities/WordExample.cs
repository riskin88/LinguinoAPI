using DAL.Configs;
using DAL.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
    [Table("WordExample")]
    public class WordExample : EntityBase
    {
        [Required]
        public string? TextL1 { get; set; }
        [Required]
        public string? TextL2 { get; set; }
        public string? AudioUrl { get; set; }
        [JsonIgnore]
        public long? WordId { get; set; }
        [JsonIgnore]
        public Word? Word { get; set; }
    }
}
