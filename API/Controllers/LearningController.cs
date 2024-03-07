using BLL.DTO;
using BLL.DTO.Exercises.Outbound;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinguinoAPI.Controllers
{
    [ApiController]
    public class LearningController : ControllerBase
    {
        private readonly ILearningService _learningService;

        public LearningController(ILearningService learningService)
        {
            _learningService = learningService;
        }

        [HttpGet, Authorize]
        [Route("/user/courses/{courseId}/study-session")]
        public async Task<ActionResult<IEnumerable<GetExerciseDTO>>> GetStudySession(long courseId, [FromQuery] SessionFilter filter)
        {
            return Ok(await _learningService.GetStudySession(courseId, filter));
        }

        [HttpPost, Authorize]
        [Route("/user/courses/{courseId}/study-session")]
        public async Task<ActionResult<PostSessionRespDTO>> PostStudySessionResults(IEnumerable<ExerciseAnswerDTO> exerciseAnswers, long courseId)
        {
            return Ok(await _learningService.PostStudySessionResults(exerciseAnswers, courseId));
        }

        [HttpGet, Authorize]
        [Route("/user/courses/{courseId}/study-map")]
        public async Task<ActionResult<IEnumerable<GetMapLessonDTO>>> GetStudyMap(long courseId, [FromQuery] StudyMapFilter filter)
        {
            return Ok(await _learningService.GetStudyMap(courseId, filter));
        }

        [HttpPut, Authorize]
        [Route("/user/courses/{courseId}/study-map/active/{lessonId}")]
        public async Task<ActionResult> ChangeActiveLesson(long courseId, long lessonId)
        {
            await _learningService.ChangeActiveLesson(courseId, lessonId);
            return NoContent();
        }

    }
}
