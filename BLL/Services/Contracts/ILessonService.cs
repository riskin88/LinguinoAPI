using BLL.DTO;
using DAL.Entities;

namespace BLL.Services.Contracts
{
    public interface ILessonService
    {
        void CreateLessonItem(CreateLessonItemDTO lessonItemDTO);
        Task<LessonRespDTO> CreateBuiltinLesson(CreateBuiltinLessonDTO builtinLessonDTO, long courseId);
        Task<LessonRespDTO> CreateCustomLesson(CreateCustomLessonDTO customLessonDTO, long courseId);
        Task AddLessonToTopic(long topicId, long lessonId);
        Task RemoveLessonFromTopic(long topicId, long lessonId);
    }
}