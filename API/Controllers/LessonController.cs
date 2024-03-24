using BLL.DTO.Lessons;
using BLL.DTO.LessonItems;
using BLL.Services.Contracts;
using DAL.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinguinoAPI.Controllers
{
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("courses/{courseId}/lessons")]
        public async Task<ActionResult<CreateLessonRespDTO>> CreateBuiltinLesson(CreateBuiltinLessonDTO lessonDTO, long courseId)
        {
            return Ok(await _lessonService.CreateBuiltinLesson(lessonDTO, courseId));
        }

        [HttpPost, Authorize(Roles = "PREMIUM_USER,ADMIN")]
        [Route("user/courses/{courseId}/lessons")]
        public async Task<ActionResult<CreateLessonRespDTO>> CreateCustomLesson(CreateCustomLessonDTO lessonDTO, long courseId)
        {
            return Ok(await _lessonService.CreateCustomLesson(lessonDTO, courseId));
        }

        [HttpPut, Authorize(Roles = "ADMIN")]
        [Route("topics/{topicId}/lessons/{lessonId}")]
        public async Task<ActionResult> AddLessonToTopic(long topicId, long lessonId)
        {
            await _lessonService.AddLessonToTopic(topicId, lessonId);
            return NoContent();
        }

        [HttpDelete, Authorize(Roles = "ADMIN")]
        [Route("topics/{topicId}/lessons/{lessonId}")]
        public async Task<ActionResult> RemoveLessonFromTopic(long topicId, long lessonId)
        {
            await _lessonService.RemoveLessonFromTopic(topicId, lessonId);
            return NoContent();
        }

        [HttpGet, Authorize]
        [Route("user/courses/{courseId}/lessons")]
        public async Task<ActionResult<IEnumerable<GetLessonBriefDTO>>> GetLessons(long courseId, [FromQuery] LessonFilter filter)
        {
            return Ok(await _lessonService.GetLessonsInCourse(courseId, filter));
        }

        [HttpGet, Authorize]
        [Route("user/courses/{courseId}/lessons/{lessonId}")]
        public async Task<ActionResult<IEnumerable<GetLessonDTO>>> GetLesson(long courseId, long lessonId)
        {
            return Ok(await _lessonService.GetLesson(courseId, lessonId));
        }

        [HttpPatch, Authorize]
        [Route("/user/courses/{courseId}/lessons/{lessonId}")]
        public async Task<ActionResult> ModifyLessonStatus(long courseId, long lessonId, LessonStatusDTO lessonStatusDTO)
        {
            await _lessonService.ModifyLessonStatus(courseId, lessonId, lessonStatusDTO);
            return NoContent();
        }

        [HttpDelete, Authorize]
        [Route("/user/courses/{courseId}/lessons/{lessonId}")]
        public async Task<ActionResult> DeleteCustomLesson(long courseId, long lessonId)
        {
            await _lessonService.DeleteCustomLesson(courseId, lessonId);
            return NoContent();
        }

        [HttpPut, Authorize]
        [Route("/user/courses/{courseId}/lessons/{lessonId}")]
        public async Task<ActionResult> ModifyCustomLesson(long courseId, long lessonId, ModifyLessonDTO modifyLessonDTO)
        {
            await _lessonService.ModifyCustomLesson(courseId, lessonId, modifyLessonDTO);
            return Ok(await _lessonService.GetLesson(courseId, lessonId));
        }

        [HttpPut, Authorize]
        [Route("user/courses/{courseId}/lessons/{lessonId}/feedback")]
        public async Task<ActionResult> ChangeFeedback(long courseId, long lessonId, LessonFeedbackDTO feedbackDTO)
        {
            await _lessonService.ChangeFeedback(courseId, lessonId, feedbackDTO);
            return NoContent();
        }

    }
}
