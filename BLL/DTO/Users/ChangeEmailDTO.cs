using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Users
{
    public class ChangeEmailDTO
    {
        [Required]
        public string? NewEmail { get; set; }
    }
}
