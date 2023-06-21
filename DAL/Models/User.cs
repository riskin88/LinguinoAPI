using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class User : EntityBase
    {
        public string? Username { get; set; }
        public long Streak { get; set; }
        public long Cash { get; set; }
        public bool Premium { get; set; }
    }
}
