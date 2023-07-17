using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CreateUserRespDTO
    {
        public string? id { get; set; }
        public string? username { get; set; }
        public long? streak { get; set; }
        public long? balance { get; set; }
        public bool? accountInitialized { get; set; }
    }
}
