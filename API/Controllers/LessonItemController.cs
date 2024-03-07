using BLL.DTO.LessonItems;
using BLL.Services.Contracts;
using DAL.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinguinoAPI.Controllers
{
    [ApiController]
    public class LessonItemController : ControllerBase
    {
        private readonly ILessonItemService _lessonItemService;

        public LessonItemController(ILessonItemService lessonItemService)
        {
            _lessonItemService = lessonItemService;
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("lesson-items")]
        public ActionResult<CreateItemRespDTO> CreateLessonItem(CreateItemDTO createItemDTO)
        {
            return Ok(_lessonItemService.CreateLessonItem(createItemDTO));
        }

        [HttpPut, Authorize(Roles = "ADMIN")]
        [Route("lessons/{lessonId}/lesson-items/{lessonItemId}")]
        public async Task<ActionResult> AddLessonItem(AddItemDTO itemDTO, long lessonId, long lessonItemId)
        {
            await _lessonItemService.AddLessonItem(itemDTO, lessonId, lessonItemId);
            return Ok();
        }

        [HttpPost, Authorize(Roles = "ADMIN")]
        [Route("lesson-items/vocabulary")]
        public ActionResult<CreateWordRespDTO> CreateWord(CreateWordDTO createWordDTO)
        {
            return Ok(_lessonItemService.CreateWord(createWordDTO));
        }

        [HttpGet, Authorize]
        [Route("/user/courses/{courseId}/vocabulary")]
        public async Task<ActionResult<IEnumerable<GetWordBriefDTO>>> GetVocabularyInCourse(long courseId, [FromQuery] VocabularyFilter filter)
        {
            return Ok(await _lessonItemService.GetVocabularyInCourse(courseId, filter));
        }

    }
}
