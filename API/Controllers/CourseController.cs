using BLL.DTO.Courses;
using BLL.DTO.Topics;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinguinoAPI.Controllers
{
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("courses")]
        public ActionResult CreateCourse(Course course)
        {
            _courseService.CreateCourse(course);
            return Ok();
        }

        [HttpGet, Authorize]
        [Route("courses")]
        public async Task<ActionResult<IEnumerable<CourseRespDTO>>> GetCourses([FromQuery] CourseFilter filter)
        {                      
            return Ok(await _courseService.GetCourses(filter));
        }

        [HttpGet, Authorize]
        [Route("user/courses")]
        public async Task<ActionResult<IEnumerable<CourseRespDTO>>> GetUserCourses()
        {
            return Ok(await _courseService.GetUserCourses());
        }


        [HttpPut, Authorize]
        [Route("user/courses/{courseId}")]
        public async Task<ActionResult<Course>> AddCourse(AddCourseDTO course, long courseId)
        {
            return Ok(await _courseService.AddUserWithTopics(course, courseId));
        }

        [HttpGet, Authorize]
        [Route("courses/{courseId}")]
        public async Task<ActionResult<CourseWithFeaturedDTO>> GetCourseWithFeaturedTopics(long courseId)
        {
            return Ok(await _courseService.GetWithFeaturedTopics(courseId));
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("courses/{courseId}/topics")]
        public async Task<ActionResult> CreateTopic(long courseId, CreateTopicDTO topic)
        {
            await _courseService.CreateTopic(courseId, topic);
            return Ok();
        }

        [HttpGet, Authorize]
        [Route("courses/{courseId}/topics")]
        public async Task<ActionResult<IEnumerable<TopicRespDTO>>> GetTopics(long courseId, [FromQuery] TopicFilter filter)
        {
            return Ok(await _courseService.GetTopics(courseId, filter));
        }

        [HttpPut, Authorize]
        [Route("user/courses/{courseId}/topics/{topicId}")]
        public async Task<ActionResult<TopicRespDTO>> AddTopicToUser(long courseId, long topicId)
        {
            await _courseService.EnableTopicInCourse(courseId, topicId);
            return NoContent();
        }

        [HttpDelete, Authorize]
        [Route("user/courses/{courseId}/topics/{topicId}")]
        public async Task<ActionResult> RemoveTopicFromUser(long courseId, long topicId)
        {
            await _courseService.DisableTopicInCourse(courseId, topicId);
            return NoContent();
        }
    }
}
