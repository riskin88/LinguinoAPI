using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("LearningStat")]
    public class LearningStat : EntityBase
    {
        public DateTime Date { get; set; }
        public long Points { get; set; } = 0;
        [JsonIgnore]
        public string? UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}
