using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Config
{
    public class EmailSettings
    {
        public string Address { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string ResetPasswordUrl { get; set; }
    }
}
