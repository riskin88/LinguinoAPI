using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CreateTopicDTO
    {
        public string Name { get; set; }
        public string ThumbnailURL { get; set; }
        public bool IsFeatured { get; set; }
        public TopicCategory Category { get; set; }
    }
}
