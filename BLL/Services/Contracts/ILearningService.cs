using BLL.DTO;
using BLL.DTO.Exercises.Outbound;
using BLL.DTO.Lessons;
using DAL.Entities;
using DAL.Filters;

namespace BLL.Services.Contracts
{
    public interface ILearningService
    {
        Task ChangeActiveLesson(long courseId, long lessonId);
        Task<IEnumerable<GetMapLessonDTO>> GetStudyMap(long courseId, StudyMapFilter filter);
        Task<IEnumerable<GetExerciseDTO>> GetStudySession(long courseId, SessionFilter filter);
        Task<PostSessionRespDTO> PostStudySessionResults(IEnumerable<ExerciseAnswerDTO> exerciseAnswers, long courseId);
    }
}