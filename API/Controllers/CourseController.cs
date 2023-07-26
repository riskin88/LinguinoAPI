using BLL.DTO;
using BLL.Services.Contracts;
using DAL.Entities;
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
        public async Task<ActionResult> CreateCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(modelState: ModelState);
            }

            await _courseService.CreateCourse(course);
            return Ok();
        }
    }
}
