using BLL.DTO;
using BLL.Services.Contracts;
using DAL.Entities;
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
        [Route("lesson-items")]
        public ActionResult CreateLessonItem(CreateLessonItemDTO lessonItemDTO)
        {
            _lessonService.CreateLessonItem(lessonItemDTO);
            return Ok();
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("courses/{courseId}/lessons/builtin")]
        public async Task<ActionResult<CreateLessonRespDTO>> CreateBuiltinLesson(CreateBuiltinLessonDTO lessonDTO, long courseId)
        {
            return Ok(await _lessonService.CreateBuiltinLesson(lessonDTO, courseId));
        }

        [HttpPost, Authorize]
        [Route("courses/{courseId}/lessons")]
        public async Task<ActionResult<CreateLessonRespDTO>> CreateCustomLesson(CreateCustomLessonDTO lessonDTO, long courseId)
        {
            return Ok(await _lessonService.CreateCustomLesson(lessonDTO, courseId));
        }

        [HttpPut, Authorize(Roles = "ADMIN")]
        [Route("topics/{topicId}/lessons/{lessonId}")]
        public async Task<ActionResult> AddLessonToTopic(long topicId, long lessonId)
        {
            await _lessonService.AddLessonToTopic(topicId, lessonId);
            return Ok();
        }

        [HttpDelete, Authorize(Roles = "ADMIN")]
        [Route("topics/{topicId}/lessons/{lessonId}")]
        public async Task<ActionResult> RemoveLessonFromTopic(long topicId, long lessonId)
        {
            await _lessonService.RemoveLessonFromTopic(topicId, lessonId);
            return NoContent();
        }

        [HttpGet, Authorize]
        [Route("courses/{courseId}/lessons")]
        public async Task<ActionResult<IEnumerable<GetLessonDTO>>> GetLessons(long courseId, [FromQuery] LessonFilter filter)
        {
            return Ok(await _lessonService.GetLessonsInCourse(courseId, filter));
        }
    }
}
