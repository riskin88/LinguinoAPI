using BLL.DTO;
using DAL.Filters;

namespace BLL.Services.Contracts
{
    public interface ILessonService
    {
        void CreateLessonItem(CreateLessonItemDTO lessonItemDTO);
        Task<CreateLessonRespDTO> CreateBuiltinLesson(CreateBuiltinLessonDTO builtinLessonDTO, long courseId);
        Task<CreateLessonRespDTO> CreateCustomLesson(CreateCustomLessonDTO customLessonDTO, long courseId);
        Task AddLessonToTopic(long topicId, long lessonId);
        Task RemoveLessonFromTopic(long topicId, long lessonId);
        Task<IEnumerable<GetLessonDTO>> GetLessonsInCourse(long courseId, LessonFilter filter);
        Task EnableLesson(long lessonId);
        Task DisableLesson(long lessonId);
    }
}