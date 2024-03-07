﻿using BLL.DTO;
using BLL.DTO.Exercises.Outbound;
using DAL.Entities;
using DAL.Filters;

namespace BLL.Services.Contracts
{
    public interface ILearningService
    {
        Task<IEnumerable<GetMapLessonDTO>> GetStudyMap(long courseId, StudyMapFilter filter);
        Task<IEnumerable<GetExerciseDTO>> GetStudySession(long courseId, SessionFilter filter);
        Task<PostSessionRespDTO> PostStudySessionResults(IEnumerable<ExerciseAnswerDTO> exerciseAnswers, long courseId);
    }
}