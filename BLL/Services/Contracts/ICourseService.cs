using BLL.DTO;
using DAL.Entities;
using DAL.Filters;

namespace BLL.Services.Contracts
{
    public interface ICourseService
    {
        void CreateCourse(Course createCourseDTO);
        public Task<IEnumerable<CourseRespDTO>> GetCourses(CourseFilter filter);
        public Task<IEnumerable<CourseRespDTO>> GetUserCourses();
        public Task CreateTopic(long id, CreateTopicDTO createTopicDTO);
        public Task<CourseRespDTO> AddUserWithTopics(AddCourseDTO courseDTO, long courseId);
        public Task<IEnumerable<TopicRespDTO>> GetTopics(long courseId, TopicFilter filter);
        public Task EnableTopic(long courseId, long topicId);
        public Task DisableTopic(long courseId, long topicId);
        public Task<CourseWithFeaturedDTO> GetWithFeaturedTopics(long courseId);

    }
}