using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Users
{
    public class RefreshTokenRespDTO
    {
        public string? IdToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
