using BLL.DTO.Lessons;
using DAL.Filters;

namespace BLL.Services.Contracts
{
    public interface ILessonService
    {
        Task<CreateLessonRespDTO> CreateBuiltinLesson(CreateBuiltinLessonDTO builtinLessonDTO, long courseId);
        Task<CreateLessonRespDTO> CreateCustomLesson(CreateCustomLessonDTO customLessonDTO, long courseId);
        Task AddLessonToTopic(long topicId, long lessonId);
        Task RemoveLessonFromTopic(long topicId, long lessonId);
        Task<IEnumerable<GetLessonBriefDTO>> GetLessonsInCourse(long courseId, LessonFilter filter);
        Task EnableLesson(long lessonId);
        Task DisableLesson(long lessonId);
        Task ChangeFeedback(long courseId, long lessonId, LessonFeedbackDTO feedbackDTO);
        Task ModifyLessonStatus(long courseId, long lessonId, LessonStatusDTO lessonStatusDTO);
        Task DeleteCustomLesson(long courseId, long lessonId);
        Task<GetLessonDTO> GetLesson(long courseId, long lessonId);
    }
}