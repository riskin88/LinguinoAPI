using AutoMapper;
using BLL.Config;
using BLL.DTO;
using BLL.DTO.Exercises.Outbound;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Entities.Enums;
using DAL.Entities.Relations;
using DAL.Exceptions;
using DAL.Filters;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore.Metadata;
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
                        if (!await _unitOfWork.LessonRepository.IsNotOwn(filter.LessonId.Value))
                        {
                            // new
                            long totalTimeNew = (long)(_configuration.SessionLengthMs * _configuration.TimeForNewItems);
                            var itemsNew = await _unitOfWork.LessonItemRepository.GetNewInLessonOrdered(filter.LessonId.Value);
                            (IEnumerable<GetExerciseDTO> exercises, long time) res = await GetExercisesForOrderedItems(itemsNew, totalTimeNew, true);
                            exerciseDTOs = res.exercises.ToList();
                            exerciseDTOs.ForEach(e =>
                            {
                                e.IsNew = true;
                                e.LessonId = filter.LessonId.Value;
                            });

                            // to review
                            long totalTimeReview = _configuration.SessionLengthMs - res.time;
                            var itemsToReview = await _unitOfWork.LessonItemRepository.GetToReviewInLessonOrdered(filter.LessonId.Value);
                            exerciseDTOs.AddRange((await GetExercisesForOrderedItems(itemsToReview, totalTimeReview, false)).Item1);
                        }
                        else throw new AccessDeniedException("You have no access to this lesson.");

                    }

                    // daily learning
                    else
                    {
                        // TODO move time from config to user settings
                        long totalTimeNew = (long)(_configuration.SessionLengthMs * _configuration.TimeForNewItems);
                        var lessonId = await _unitOfWork.CourseRepository.GetActiveLessonId(courseId);
                        var itemsNew = await _unitOfWork.LessonItemRepository.GetNewInLessonOrdered(lessonId);
                        (IEnumerable<GetExerciseDTO> exercises, long time) res = await GetExercisesForOrderedItems(itemsNew, totalTimeNew, true);
                        exerciseDTOs = res.exercises.ToList();
                        exerciseDTOs.ForEach(e =>
                        {
                            e.IsNew = true;
                            e.LessonId = lessonId;
                        });

                        // review
                        long totalTimeReview = _configuration.SessionLengthMs - res.time;
                        var itemsToReview = await _unitOfWork.LessonItemRepository.GetOverdueToReviewInCourseOrdered(courseId);
                        exerciseDTOs.AddRange((await GetExercisesForOrderedItems(itemsToReview, totalTimeReview, false)).Item1);
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

            var itemType = item.Type;
            string? enumName = Enum.GetName(typeof(LessonType), itemType);
            if (enumName != null)
            {
                typeStr = enumName;
            }
            else throw new MyBadException(null);

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

        private async Task<(IEnumerable<GetExerciseDTO>, long)> GetExercisesForOrderedItems(IEnumerable<LessonItem> itemsAll, long limitTime, bool isNew)
        {
            List<GetExerciseDTO> exercisesAll = new();
            long totalTime = 0;
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
                        int numberOfExercises = GetNumberOfExercises(item, isNew);
                        exercises.AddRange(await _unitOfWork.ExerciseRepository.GetRandomFromItem(item.Id, numberOfExercises));
                    }
                }

                else
                {
                    int numberOfExercises = GetNumberOfExercises(item, isNew);
                    exercises.AddRange(await _unitOfWork.ExerciseRepository.GetRandomFromItem(item.Id, numberOfExercises));
                }

                long itemTime = 0;
                foreach (var exercise in exercises)
                {
                    itemTime += exercise.EstimatedTimeMs;
                }
                if (totalTime + itemTime > limitTime)
                {
                    break;
                }
                totalTime += itemTime;

                var exerciseDTOs = _mapper.Map<IEnumerable<Exercise>, List<GetExerciseDTO>>(exercises);
                foreach (var exercise in exerciseDTOs)
                {
                    exercise.LessonItemType = item.Type;
                }

                exercisesAll.AddRange(exerciseDTOs);

            }
            return (exercisesAll, totalTime);
        }

        public async Task<PostSessionRespDTO> PostStudySessionResults(IEnumerable<ExerciseAnswerDTO> exerciseAnswers, long courseId)
        {
            bool movePosition = false;
            var userCourse = await _unitOfWork.CourseRepository.GetUserCourse(courseId);
            var itemResults = exerciseAnswers.GroupBy(x => x.LessonItemId)
                          .Select(g => new
                          {
                              lessonItemId = g.Key,
                              averageRating = g.Average(x => x.AnswerRating)
                          });
            foreach (var itemResult in itemResults)
            {
                var userLessonItem = await _unitOfWork.LessonItemRepository.GetUserProgress(itemResult.lessonItemId);
                if (userLessonItem.ItemState == LessonItemState.NEW)
                {
                    var userLessons = await _unitOfWork.LessonItemRepository.GetUserLessons(itemResult.lessonItemId);
                    foreach (var userLesson in userLessons)
                    {
                        if (userLesson.Lesson.CourseId != courseId)
                            throw new CourseMismatchException("Lesson item does not belong to this course.");
                        if (++userLesson.ItemsDone >= userLesson.Lesson.ItemsTotal && !userLesson.Lesson.IsCustom)
                        {
                            if (userLesson.Lesson.OrderOnMap >= userCourse.PositionOnMap)
                                movePosition = true;
                        }
                    }
                }
                UpdateUserProgress(userLessonItem, itemResult.averageRating);
            }
            if (movePosition)
                await _unitOfWork.CourseRepository.MovePositionOnMap(courseId);
            var user = _unitOfWork.UserRepository.GetUser();
            int points = exerciseAnswers.Count() * _configuration.PointsForExercise;
            user.Balance += points;
            // last session was before yesterday
            if (user.LastSessionDate == null || user.LastSessionDate < DateTime.Today.AddDays(-1))
            {
                user.Streak = 0;
            }
            else
            {
                user.Streak++;
            }
            user.LastSessionDate = DateTime.Today;
            _unitOfWork.SaveChanges();
            return new PostSessionRespDTO { Reward = points };

        }

        private void UpdateUserProgress(UserLessonItem progress, double averageRating)
        {
            int responseQuality = (int)Math.Round(averageRating / 20.0);
            if (responseQuality < 3)
            {
                progress.Repetitions = 1;
                progress.Interval = 1;
            }
            else
            {
                switch (progress.Repetitions)
                {
                    case 0:
                        progress.Interval = 1; break;
                    case 1:
                        progress.Interval = 6; break;
                    default:
                        progress.Interval = (int)Math.Ceiling(progress.Interval * progress.Easiness); break;
                }
                progress.Repetitions++;
                progress.Easiness = SM2.ComputeEF(progress.Easiness, responseQuality);
            }

            if (progress.ItemState == LessonItemState.NEW)
            {
                progress.ItemState = LessonItemState.REVIEW;
            }
            
            progress.DateToReview = DateTime.Today.AddDays(progress.Interval);

        }

        public async Task<IEnumerable<GetMapLessonDTO>> GetStudyMap(long courseId, StudyMapFilter filter)
        {
            if (await _unitOfWork.CourseRepository.IsEnrolled(courseId))
            {
                var lessons = await _unitOfWork.LessonRepository.GetBuiltInLessonsFromCourseOrdered(courseId, filter);
                var lessonDTOs = _mapper.Map<IEnumerable<Lesson>, List<GetMapLessonDTO>>(lessons);
                var activeLessonId = await _unitOfWork.CourseRepository.GetActiveLessonId(courseId);
                foreach (var lessonDTO in lessonDTOs)
                {
                    if (lessonDTO.Id == activeLessonId)
                        lessonDTO.IsActive = true;
                }
                return lessonDTOs;
            }
            else throw new UserNotInCourseException();
        }

        public async Task ChangeActiveLesson(long courseId, long lessonId)
        {
            if (await _unitOfWork.CourseRepository.IsEnrolled(courseId))
            {
                var lesson = await _unitOfWork.LessonRepository.GetById(lessonId);
                if (lesson != null)
                {
                    if (lesson.CourseId == courseId && !lesson.IsCustom)
                    {
                        var userCourse = await _unitOfWork.CourseRepository.GetUserCourse(courseId);
                        userCourse.PositionOnMap = (long)lesson.OrderOnMap;
                        _unitOfWork.SaveChanges();
                        
                    }
                    else throw new CourseMismatchException("The lesson does not belong to this course.");
                }
                else throw new InvalidIDException("Lesson does not exist.");

            }
            else throw new UserNotInCourseException();
        }
    }

    static class SM2
    {
        public static double ComputeEF(double oldEF, int responseQuality)
        {
            double newEF = oldEF + (0.1 - (5.0 - responseQuality) * (0.08 + (5.0 - responseQuality) * 0.02));
            return (newEF >= 1.3) ? newEF : 1.3;
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
