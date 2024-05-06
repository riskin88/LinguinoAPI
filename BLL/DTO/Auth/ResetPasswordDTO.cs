using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.Auth
{
    public class ResetPasswordDTO
    {
        [Required]
        public string Email { get; set; }
    }
}