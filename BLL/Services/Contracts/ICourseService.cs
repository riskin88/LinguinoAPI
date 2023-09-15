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
        public Task CreateTopic(long id, CreateTopicDTO createTopicDTO);
        public Task<CourseRespDTO> AddUserWithTopics(AddCourseDTO courseDTO, string userId);
        public Task<IEnumerable<TopicRespDTO>> GetTopics(long courseId, TopicFilter filter);
        public Task<TopicRespDTO> ToggleTopic(string userId, long courseId, long topicId, ToggleTopicDTO topicDTO);

    }
}