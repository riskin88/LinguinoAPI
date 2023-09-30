﻿using AutoMapper;
using BLL.DTO;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Exceptions;
using DAL.Filters;
using DAL.UnitOfWork;

namespace BLL.Services
{
    public class LessonService : ILessonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LessonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateLessonItem(CreateLessonItemDTO lessonItemDTO)
        {
            var lessonItem = _mapper.Map<LessonItem>(lessonItemDTO);
            _unitOfWork.LessonItemRepository.Add(lessonItem);
            _unitOfWork.SaveChanges();
        }

        public async Task<CreateLessonRespDTO> CreateBuiltinLesson(CreateBuiltinLessonDTO builtinLessonDTO, long courseId)
        {
            var course = await _unitOfWork.CourseRepository.GetById(courseId);
            if (course != null)
            {
                var lesson = _mapper.Map<Lesson>(builtinLessonDTO);
                lesson.IsCustom = false;
                _unitOfWork.LessonRepository.Add(lesson);
                lesson.Course = course;
                // add record to the M:N join table
                var users = await _unitOfWork.CourseRepository.GetUsersWithLessons(courseId);
                foreach (var user in users)
                {
                    user.Lessons.Add(lesson);
                }
                foreach (var itemDTO in builtinLessonDTO.Items)
                {
                    var item = await _unitOfWork.LessonItemRepository.GetById(itemDTO.Id);
                    if (item != null)
                        _unitOfWork.LessonRepository.AddLessonItem(lesson, item);
                    else throw new InvalidIDException("Item " + itemDTO.Id + " does not exist.");
                }
                _unitOfWork.SaveChanges();
                return _mapper.Map<CreateLessonRespDTO>(lesson);
            }
            else throw new InvalidIDException("Course does not exist.");
        }

        // TODO: CHECK if all items are vocab
        public async Task<CreateLessonRespDTO> CreateCustomLesson(CreateCustomLessonDTO customLessonDTO, long courseId)
        {
            var course = await _unitOfWork.CourseRepository.GetById(courseId);
            if (course != null)
            {
                if (await _unitOfWork.CourseRepository.IsEnrolled(courseId))
                {
                    var lesson = _mapper.Map<Lesson>(customLessonDTO);
                    lesson.IsCustom = true;
                    _unitOfWork.LessonRepository.Add(lesson);
                    lesson.Course = course;
                    _unitOfWork.LessonRepository.AddAuthor(lesson);
                    // add record to the M:N join table
                    var users = await _unitOfWork.CourseRepository.GetUsersWithLessons(courseId);
                    foreach (var user in users)
                    {
                        user.Lessons.Add(lesson);
                    }
                    foreach (var itemDTO in customLessonDTO.Items)
                    {
                        var item = await _unitOfWork.LessonItemRepository.GetById(itemDTO.Id);
                        if (item != null)
                            _unitOfWork.LessonRepository.AddLessonItem(lesson, item);
                        else throw new InvalidIDException("Item " + itemDTO.Id + " does not exist.");
                    }
                    _unitOfWork.SaveChanges();
                    return _mapper.Map<CreateLessonRespDTO>(lesson);
                }
                else throw new InvalidIDException("You are not enrolled in this course.");
            }
            else throw new InvalidIDException("Course does not exist.");
        }

        public async Task AddLessonToTopic(long topicId, long lessonId)
        {
            var topic = await _unitOfWork.TopicRepository.GetById(topicId);
            if (topic != null)
            {
                await _unitOfWork.LessonRepository.AddTopic(lessonId, topic);
                var userTopics = await _unitOfWork.TopicRepository.GetUserTopics(topic.Id);
                foreach(var userTopic in userTopics)
                {
                    if (userTopic.IsEnabled)
                    {
                        await _unitOfWork.LessonRepository.EnableLesson(userTopic.UserId, lessonId);
                        userTopic.LessonsActive++;
                    }

                }
                topic.LessonsTotal++;
                _unitOfWork.SaveChanges();
            }
            else throw new InvalidIDException("Topic does not exist.");
        }

        public async Task RemoveLessonFromTopic(long topicId, long lessonId)
        {
            var topic = await _unitOfWork.TopicRepository.GetById(topicId);
            if (topic != null)
            {
                await _unitOfWork.LessonRepository.RemoveTopic(lessonId, topic);
                _unitOfWork.SaveChanges();
            }
            else throw new InvalidIDException("Topic does not exist.");
        }

        public async Task<IEnumerable<GetLessonDTO>> GetLessonsInCourse(long courseId, LessonFilter filter)
        {
            var courseLessons = await _unitOfWork.LessonRepository.GetLessonsFromCourse(courseId, filter);
            List<GetLessonDTO> resp = new();
            foreach (var lesson in courseLessons)
            {
                var tmp = _mapper.Map<GetLessonDTO>(lesson);
                if (_unitOfWork.LessonRepository.IsFavorite(lesson.Id))
                    tmp.isFavorite = true;
                resp.Add(tmp);
            }
            return resp;
        }

        public async Task EnableLesson(long lessonId)

        {
            if (await _unitOfWork.LessonRepository.EnableOwn(lessonId))
            {
                var userTopics = await _unitOfWork.LessonRepository.GetUserTopics(lessonId);
                foreach (var ut in userTopics)
                {
                    ut.LessonsActive++;
                    if (ut.LessonsActive == ut.Topic.LessonsTotal)
                        ut.IsEnabled = true;
                }
            }
            _unitOfWork.SaveChanges();
        }

        public async Task DisableLesson(long lessonId)
        {
            if (await _unitOfWork.LessonRepository.DisableOwn(lessonId))
            {
                var userTopics = await _unitOfWork.LessonRepository.GetUserTopics(lessonId);
                foreach (var ut in userTopics)
                {
                    ut.LessonsActive--;
                    if (ut.LessonsActive == 0)
                        ut.IsEnabled = false;
                }
            }
            _unitOfWork.SaveChanges();
        }
    }
}
