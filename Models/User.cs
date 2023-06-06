using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinguinoAPI.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public long Streak { get; set; }
        public long Cash { get; set; }
        public bool Premium { get; set; }
    }
}
