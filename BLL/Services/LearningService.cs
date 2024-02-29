﻿using AutoMapper;
using BLL.Config;
using BLL.DTO.Exercises.Outbound;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Entities.Enums;
using DAL.Exceptions;
using DAL.Filters;
using DAL.UnitOfWork;
using Microsoft.Extensions.Options;

namespace BLL.Services
{
    public class LearningService : ILearningService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly LearningSettings _configuration;

        public LearningService(IUnitOfWork unitOfWork, IMapper mapper, IOptions<LearningSettings> configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration.Value;
        }


        public async Task<IEnumerable<GetExerciseDTO>> GetStudySession(long courseId, SessionFilter filter)
        {
            var course = await _unitOfWork.CourseRepository.GetById(courseId);
            if (course != null)
            {
                if (await _unitOfWork.CourseRepository.IsEnrolled(courseId))
                {
                    List<GetExerciseDTO> exerciseDTOs = new();
                    // study specific lesson
                    if (filter.LessonId != null)
                    {
                        // new
                        long totalTimeNew = (long)(_configuration.SessionLengthMs * _configuration.TimeForNewItems);
                        var itemsNew = await _unitOfWork.LessonItemRepository.GetNewInLessonOrdered(filter.LessonId.Value);
                        (IEnumerable<Exercise> exercises, long time) res = await GetExercisesForOrderedItems(itemsNew, totalTimeNew);
                        exerciseDTOs = _mapper.Map<IEnumerable<Exercise>, List<GetExerciseDTO>>(res.exercises);
                        exerciseDTOs.ForEach(e =>
                        {
                            e.IsNew = true;
                            e.LessonId = filter.LessonId.Value;
                            });

                        // to review
                        long totalTimeReview = _configuration.SessionLengthMs - res.time;
                        var itemsToReview = await _unitOfWork.LessonItemRepository.GetToReviewInLessonOrdered(filter.LessonId.Value);
                        exerciseDTOs.AddRange(_mapper.Map<IEnumerable<Exercise>, List<GetExerciseDTO>>((await GetExercisesForOrderedItems(itemsToReview, totalTimeReview)).Item1));
                    }

                    // daily learning
                    else
                    {
                        // TODO move time from config to user settings
                        long totalTimeNew = (long)(_configuration.SessionLengthMs * _configuration.TimeForNewItems);
                        var lessonId = await _unitOfWork.CourseRepository.GetNextLessonId(courseId);
                        var itemsNew = await _unitOfWork.LessonItemRepository.GetNewInLessonOrdered(lessonId);
                        (IEnumerable<Exercise> exercises, long time) res = await GetExercisesForOrderedItems(itemsNew, totalTimeNew);
                        exerciseDTOs = _mapper.Map<IEnumerable<Exercise>, List<GetExerciseDTO>>(res.exercises);
                        exerciseDTOs.ForEach(e =>
                        {
                            e.IsNew = true;
                            e.LessonId = lessonId;
                        });

                        // review
                        long totalTimeReview = _configuration.SessionLengthMs - res.time;
                        var itemsToReview = await _unitOfWork.LessonItemRepository.GetOverdueToReviewInCourseOrdered(courseId);
                        exerciseDTOs.AddRange(_mapper.Map<IEnumerable<Exercise>, List<GetExerciseDTO>>((await GetExercisesForOrderedItems(itemsToReview, totalTimeReview)).Item1));
                    }

                    exerciseDTOs.Shuffle();
                    return exerciseDTOs;
                }
                else throw new UserNotInCourseException();

            }
            else throw new InvalidIDException("Course does not exist.");
        }

        private int GetNumberOfExercises(LessonItem item, bool isNew)
        {
            string typeStr = "";
            if (item is Word)
            {
                typeStr = "WORD";
            }
            else
            {
                var itemType = item.Type;
                string? enumName = Enum.GetName(typeof(LessonItemType), itemType);
                if (enumName != null)
                {
                    typeStr = enumName;
                }
                else throw new MyBadException(null);
            }

            if (isNew)
            {
                typeStr += "_NEW";
            }
            else
            {
                typeStr += "_REVIEW";
            }
            var settingsValues = _configuration.ExercisesInSession;

            if (settingsValues.ContainsKey(typeStr))
            {
                return settingsValues[typeStr];
            }
            else throw new MyBadException("Lesson item type not found in config.");
        }

        private async Task<(IEnumerable<Exercise>, long)> GetExercisesForOrderedItems(IEnumerable<LessonItem> itemsAll, long totalTime)
        {
            List<Exercise> exercisesAll = new();
            long currentTime = 0;
            foreach (var item in itemsAll)
            {
                List<Exercise> exercises = new();
                var progress = await _unitOfWork.LessonItemRepository.GetUserProgress(item.Id);
                // learning steps defined
                if (item.LearningSteps.Count > 0)
                {
                    var step = item.LearningSteps.OrderBy(ls => ls.ToInterval).FirstOrDefault(ls => ls.ToInterval >= progress.Interval);
                    if (step != null)
                    {
                        exercises.AddRange(await _unitOfWork.ExerciseRepository.GetFromStep(step.Id));
                    }
                    else
                    {
                        int numberOfExercises = GetNumberOfExercises(item, true);
                        exercises.AddRange(await _unitOfWork.ExerciseRepository.GetRandomFromItem(item.Id, numberOfExercises));
                    }
                }

                else
                {
                    int numberOfExercises = GetNumberOfExercises(item, true);
                    exercises.AddRange(await _unitOfWork.ExerciseRepository.GetRandomFromItem(item.Id, numberOfExercises));
                }

                foreach (var exercise in exercises)
                {
                    currentTime += exercise.EstimatedTimeMs;
                }
                if (currentTime > totalTime)
                {
                    break;
                }
                exercisesAll.AddRange(exercises);

            }
            return (exercisesAll, currentTime);
        }

    }


    static class Shuffler
    {
        private static readonly Random rng = new();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
