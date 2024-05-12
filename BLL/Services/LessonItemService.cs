using AutoMapper;
using BLL.Config;
using BLL.DTO.LessonItems;
using BLL.DTO.Lessons;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Entities.Enums;
using DAL.Exceptions;
using DAL.Filters;
using DAL.Migrations;
using DAL.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class LessonItemService : ILessonItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly LearningSettings _configuration;

        public LessonItemService(IUnitOfWork unitOfWork, IMapper mapper, IOptions<LearningSettings> configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration.Value;
        }

        public CreateItemRespDTO CreateLessonItem(CreateItemDTO createItemDTO)
        {
            var item = _mapper.Map<LessonItem>(createItemDTO);
            _unitOfWork.LessonItemRepository.AddItem(item);
            _unitOfWork.SaveChanges();
            return _mapper.Map<CreateItemRespDTO>(item);
        }

        public async Task AddLessonItem(AddItemDTO itemDTO, long lessonId, long lessonItemId)
        {
            var lesson = await _unitOfWork.LessonRepository.GetById(lessonId);
            if (lesson != null)
            {
                var item = await _unitOfWork.LessonItemRepository.GetById(lessonItemId);
                if (item != null)
                {
                    if (item.Type == lesson.Type)
                        await _unitOfWork.LessonRepository.AddLessonItemWithOrder(lesson.Id, item, itemDTO.OrderInLesson);
                    else throw new LessonTypeMismatchException();
                }
                else throw new InvalidIDException("Lesson item does not exist.");
                var users = await _unitOfWork.LessonRepository.GetUsers(lessonId);
                foreach (var user in users)
                {
                    await _unitOfWork.LessonItemRepository.AddToUser(lessonItemId, user);
                }

                _unitOfWork.SaveChanges();
            }
            else throw new InvalidIDException("Lesson does not exist.");
        }

        public async Task AddWordToCustom(long courseId, long lessonId, long wordId)
        {
            if (await _unitOfWork.CourseRepository.IsEnrolled(courseId))
            {
                var lesson = await _unitOfWork.LessonRepository.GetForUser(lessonId);
                if (lesson.CourseId == courseId)
                {
                    if (lesson.IsCustom)
                    {
                        var item = await _unitOfWork.LessonItemRepository.GetWordById(wordId);
                        if (item != null)
                        {
                            if (await _unitOfWork.LessonRepository.AddLessonItem(lessonId, item))
                            {
                                var userItem = await _unitOfWork.LessonItemRepository.GetUserLessonItem(item.Id);
                                var userLesson = await _unitOfWork.LessonRepository.GetUserLesson(lesson.Id);
                                if (userItem != null && userItem.ItemState == LessonItemState.REVIEW)
                                {
                                    userLesson.ItemsDone++;

                                }
                                if (userLesson.ItemsDone >= userLesson.Lesson.ItemsTotal)
                                {
                                    userLesson.IsLearned = true;
                                }
                                else
                                    userLesson.IsLearned = false;
                            }
                            
                        }
                        else throw new InvalidIDException("Word does not exist.");
                        var users = await _unitOfWork.LessonRepository.GetUsers(lessonId);
                        foreach (var user in users)
                        {
                            await _unitOfWork.LessonItemRepository.AddToUser(wordId, user);
                        }

                        _unitOfWork.SaveChanges();
                    }
                    else throw new AccessDeniedException("You have not created this lesson.");
                }
                else throw new InvalidIDException("No such lesson in this course.");

            }
            else throw new UserNotInCourseException();
        }

        public async Task RemoveWordFromCustom(long courseId, long lessonId, long wordId)
        {
            if (await _unitOfWork.CourseRepository.IsEnrolled(courseId))
            {
                var lesson = await _unitOfWork.LessonRepository.GetForUser(lessonId);
                if (lesson.CourseId == courseId)
                {
                    if (lesson.IsCustom)
                    {
                        var item = await _unitOfWork.LessonItemRepository.GetWordById(wordId);
                        if (item != null)
                        {
                            if(await _unitOfWork.LessonRepository.RemoveWord(lessonId, item)){
                                var userItem = await _unitOfWork.LessonItemRepository.GetUserLessonItem(item.Id);
                                var userLesson = await _unitOfWork.LessonRepository.GetUserLesson(lesson.Id);
                                if (userItem != null && userItem.ItemState == LessonItemState.REVIEW)
                                {
                                    userLesson.ItemsDone--;
                                }
                                else if(userItem != null && userItem.ItemState == LessonItemState.NEW)
                                {
                                    if (userLesson.ItemsDone >= userLesson.Lesson.ItemsTotal)
                                    {
                                        userLesson.IsLearned = true;
                                    }

                                }
                            }

                        }
                        else throw new InvalidIDException("Word does not exist.");

                        _unitOfWork.SaveChanges();
                    }
                    else throw new AccessDeniedException("You have not created this lesson.");
                }
                else throw new InvalidIDException("No such lesson in this course.");
            }
            else throw new UserNotInCourseException();

        }

        public CreateWordRespDTO CreateWord(CreateWordDTO createWordDTO)
        {
            var word = _mapper.Map<Word>(createWordDTO);
            _unitOfWork.LessonItemRepository.AddWord(word);
            _unitOfWork.SaveChanges();
            return _mapper.Map<CreateWordRespDTO>(word);

        }

        public async Task<IEnumerable<GetWordBriefDTO>> GetVocabularyInCourse(long courseId, VocabularyFilter filter)
        {
            if (await _unitOfWork.CourseRepository.IsEnrolled(courseId))
            {
                var vocab = await _unitOfWork.LessonItemRepository.GetVocabularyInCourse(courseId, filter);
                return _mapper.Map<List<GetWordBriefDTO>>(vocab);
            }
            throw new UserNotInCourseException();
        }

        public async Task<GetWordDTO> GetWordDetails(long courseId, long wordId)
        {
            if (await _unitOfWork.CourseRepository.IsEnrolled(courseId))
            {
                var word = await _unitOfWork.LessonItemRepository.GetWordWithExamples(wordId);
                if (word != null)
                {
                    if (await _unitOfWork.LessonItemRepository.WordInCourse(wordId, courseId))
                    {
                        var wordDTO = _mapper.Map<GetWordDTO>(word);

                        if (_unitOfWork.LessonItemRepository.IsFavorite(wordId))
                            wordDTO.Favorite = true;

                        var userLessonItem = await _unitOfWork.LessonItemRepository.GetUserLessonItem(wordId);
                        wordDTO.LearningState = userLessonItem.ItemState;
                        if (userLessonItem.ItemState == LessonItemState.REVIEW)
                        {
                            wordDTO.DateToReview = userLessonItem.DateToReview.Value.Date;
                        }
                        
                        return wordDTO;
                    }
                    else throw new InvalidIDException("No such word in this course.");
                }
                else throw new InvalidIDException("Word does not exist.");
            }
            else throw new UserNotInCourseException();
        }

        public async Task ModifyWordStatus(long courseId, long wordId, LessonItemStatusDTO lessonItemStatusDTO)
        {
            if (await _unitOfWork.CourseRepository.IsEnrolled(courseId))
            {
                var word = await _unitOfWork.LessonItemRepository.GetWordById(wordId);
                if (word != null)
                {
                    if (await _unitOfWork.LessonItemRepository.WordInCourse(wordId, courseId))
                    {
                        var userLessonItem = await _unitOfWork.LessonItemRepository.GetUserLessonItem(wordId);
                        if (lessonItemStatusDTO.Favorite != null)
                        {
                            userLessonItem.IsFavorite = lessonItemStatusDTO.Favorite.Value;
                        }
                        if (lessonItemStatusDTO.MarkAsLearned == true)
                        {

                            userLessonItem.Easiness = _configuration.BoostEasiness;
                            userLessonItem.Interval = _configuration.BoostInterval;
                            userLessonItem.Repetitions = _configuration.BoostRepetitions;
                            userLessonItem.DateToReview = DateTime.Today.AddDays(userLessonItem.Interval);
                            userLessonItem.ItemState = LessonItemState.REVIEW;

                            if (userLessonItem.ItemState == LessonItemState.NEW)
                            {
                                var userLessons = await _unitOfWork.LessonItemRepository.GetUserLessons(wordId);
                                foreach (var userLesson in userLessons)
                                {
                                    if (++userLesson.ItemsDone >= userLesson.Lesson.ItemsTotal)
                                    {
                                        userLesson.IsLearned = true;
                                    }
                                }
                            }
                        }
                        _unitOfWork.SaveChanges();
                    }
                    else throw new InvalidIDException("No such word in this course.");
                }
                else throw new InvalidIDException("Word does not exist.");
            }
            else throw new UserNotInCourseException();
        }
    }
}
