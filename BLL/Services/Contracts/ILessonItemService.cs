using BLL.DTO.LessonItems;
using BLL.DTO.Lessons;
using DAL.Filters;

namespace BLL.Services.Contracts
{
    public interface ILessonItemService
    {
        Task AddLessonItem(AddItemDTO itemDTO, long lessonId, long lessonItemId);
        CreateItemRespDTO CreateLessonItem(CreateItemDTO createItemDTO);
        CreateWordRespDTO CreateWord(CreateWordDTO createWordDTO);
        Task<IEnumerable<GetWordBriefDTO>> GetVocabularyInCourse(long courseId, VocabularyFilter filter);
        Task AddWordToCustom(long courseId, long lessonId, long wordId);
        Task RemoveWordFromCustom(long courseId, long lessonId, long wordId);
        Task<GetWordDTO> GetWordDetails(long courseId, long wordId);
        Task ModifyWordStatus(long courseId, long wordId, LessonItemStatusDTO lessonItemStatusDTO);
    }
}