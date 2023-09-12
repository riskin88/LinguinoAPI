using BLL.DTO;
using DAL.Entities;
using DAL.Filters;

namespace BLL.Services.Contracts
{
    public interface ICourseService
    {
        void CreateCourse(Course createCourseDTO);
        public Task<IEnumerable<CourseRespDTO>> GetCourses(CourseFilter filter);
        public Task<IEnumerable<CourseRespDTO>> GetUserCourses(string id);
        public Task CreateTopic(long id, Topic createTopicDTO);
        public Task<CourseRespDTO> AddUser(AddCourseDTO courseDTO, string userId);
    }
}