using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TopicRespDTO : EntityBase
    {
        public string? Name { get; set; }
        public string? ThumbnailURL { get; set; }
        public bool Enabled { get; set; } = false;
    }
}
