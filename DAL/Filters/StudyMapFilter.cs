using DAL.Entities.Enums;

namespace DAL.Filters
{
    public class StudyMapFilter
    {
        public LessonLevel? Level { get; set; }
        public int? Page {  get; set; }
        public int? Limit { get; set;}
    }
}
