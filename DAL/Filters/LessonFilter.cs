using DAL.Entities.Enums;

namespace DAL.Filters
{
    public class LessonFilter
    {
        public LessonType? Type { get; set; }
        public LessonLevel? Level { get; set; }
        public bool? Custom { get; set; }
        public bool? Favorite { get; set; }
    }
}
