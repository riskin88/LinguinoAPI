using BLL.DTO;
using DAL.Entities;
using DAL.Filters;

namespace BLL.Services.Contracts
{
    public interface ICourseService
    {
        void CreateCourse(Course createCourseDTO);
        public Task<IEnumerable<Course>> GetCourses(CourseFilter filter);
        public Task<IEnumerable<Course>> GetUserCourses(string id);
        public Task CreateTopic(long id, Topic createTopicDTO);
    }
}