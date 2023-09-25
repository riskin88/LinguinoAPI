using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Exceptions.Auth;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Exceptions;
using DAL.Filters;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Http.HttpResults;

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
                if (_unitOfWork.LessonRepository.IsFavorite(lesson))
                    tmp.isFavorite = true;
                resp.Add(tmp);
            }
            return resp;
        }
    }
}
