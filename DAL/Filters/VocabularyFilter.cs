using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Filters
{
    public class VocabularyFilter
    {
        public bool? Favorite { get; set; }
        public string? SearchName { get; set; }
    }
}
