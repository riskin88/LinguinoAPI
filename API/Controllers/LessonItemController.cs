using BLL.DTO.LessonItems;
using BLL.DTO.Lessons;
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
            return NoContent();
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

        [HttpGet, Authorize]
        [Route("/user/courses/{courseId}/vocabulary/{wordId}")]
        public async Task<ActionResult<GetWordDTO>> GetWordDetails(long courseId, long wordId)
        {
            return Ok(await _lessonItemService.GetWordDetails(courseId, wordId));
        }

        [HttpPatch, Authorize]
        [Route("/user/courses/{courseId}/vocabulary/{wordId}")]
        public async Task<ActionResult<GetWordDTO>> ModifyWordStatus(long courseId, long wordId, LessonItemStatusDTO lessonItemStatusDTO)
        {
            await _lessonItemService.ModifyWordStatus(courseId, wordId, lessonItemStatusDTO);
            return Ok(await _lessonItemService.GetWordDetails(courseId, wordId));
        }

        [HttpPut, Authorize]
        [Route("user/courses/{courseId}/lessons/{lessonId}/lesson-items/{lessonItemId}")]
        public async Task<ActionResult> AddWordToCustom(long courseId, long lessonId, long lessonItemId)
        {
            await _lessonItemService.AddWordToCustom(courseId, lessonId, lessonItemId);
            return NoContent();
        }

        [HttpDelete, Authorize]
        [Route("user/courses/{courseId}/lessons/{lessonId}/lesson-items/{lessonItemId}")]
        public async Task<ActionResult> RemoveWordFromCustom(long courseId, long lessonId, long lessonItemId)
        {
            await _lessonItemService.RemoveWordFromCustom(courseId, lessonId, lessonItemId);
            return NoContent();
        }

    }
}
