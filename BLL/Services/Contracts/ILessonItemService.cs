using BLL.DTO.LessonItems;
using DAL.Filters;

namespace BLL.Services.Contracts
{
    public interface ILessonItemService
    {
        Task AddLessonItem(AddItemDTO itemDTO, long lessonId, long lessonItemId);
        CreateItemRespDTO CreateLessonItem(CreateItemDTO createItemDTO);
        CreateWordRespDTO CreateWord(CreateWordDTO createWordDTO);
        Task<IEnumerable<GetWordBriefDTO>> GetVocabularyInCourse(long courseId, VocabularyFilter filter);
    }
}