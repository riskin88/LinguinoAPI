using BLL.DTO.Courses;
using BLL.DTO.Topics;
using DAL.Entities;
using DAL.Filters;

namespace BLL.Services.Contracts
{
    public interface ICourseService
    {
        void CreateCourse(Course createCourseDTO);
        public Task<IEnumerable<GetCourseDTO>> GetCourses(CourseFilter filter);
        public Task<IEnumerable<GetCourseDTO>> GetUserCourses();
        public Task CreateTopic(long id, CreateTopicDTO createTopicDTO);
        public Task AddUserWithTopics(AddCourseDTO courseDTO, long courseId);
        public Task<IEnumerable<TopicRespDTO>> GetTopics(long courseId, TopicFilter filter);
        public Task EnableTopicInCourse(long courseId, long topicId);
        public Task DisableTopicInCourse(long courseId, long topicId);
        public Task<CourseWithFeaturedDTO> GetWithFeaturedTopics(long courseId);
        Task SelectCourse(long courseId);
    }
}