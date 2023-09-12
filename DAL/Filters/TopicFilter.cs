using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Filters
{
    public class TopicFilter
    {
        public TopicCategory? Category { get; set; }
        public bool? IsFeatured { get; set; }
    }
}
