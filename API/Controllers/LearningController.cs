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

    }
}
