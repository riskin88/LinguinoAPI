using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.Auth
{
    public class ChangePasswordDTO
    {
        [Required]
        public string ResetToken { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}