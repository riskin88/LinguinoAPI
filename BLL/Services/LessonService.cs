using AutoMapper;
using BLL.DTO;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Entities.Relations;
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

        public IdDTO CreateLessonItem()
        {
            var lessonItem = _unitOfWork.LessonItemRepository.CreateNew();
            _unitOfWork.SaveChanges();
            IdDTO dto = new()
            {
                Id = lessonItem.Id
            };
            return dto;
        }

        public CreateWordRespDTO CreateWord(CreateWordDTO createWordDTO)
        {
            var word = _mapper.Map<Word>(createWordDTO);
            _unitOfWork.LessonItemRepository.AddWord(word);
            _unitOfWork.SaveChanges();
            return _mapper.Map<CreateWordRespDTO>(word);

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
                var users = await _unitOfWork.CourseRepository.GetUsers(courseId);
                foreach (var user in users)
                {
                    await _unitOfWork.LessonRepository.AddToUser(lesson.Id, user);
                }
                foreach (var itemDTO in builtinLessonDTO.Items)
                {
                    var item = await _unitOfWork.LessonItemRepository.GetById(itemDTO.Id);
                    if (item != null)
                        await _unitOfWork.LessonRepository.AddLessonItemWithOrder(lesson.Id, item, itemDTO.OrderInLesson);
                    else throw new InvalidIDException("Item " + itemDTO.Id + " does not exist.");
                }
                _unitOfWork.SaveChanges();
                return _mapper.Map<CreateLessonRespDTO>(lesson);
            }
            else throw new InvalidIDException("Course does not exist.");
        }

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
                    await _unitOfWork.LessonRepository.AddToSelf(lesson.Id);
                    foreach (var itemDTO in customLessonDTO.Items)
                    {
                        var word = await _unitOfWork.LessonItemRepository.GetWordById(itemDTO.Id);
                        if (word != null)
                            await _unitOfWork.LessonRepository.AddLessonItem(lesson.Id, word);
                        else throw new InvalidIDException("Word " + itemDTO.Id + " does not exist.");
                    }
                    _unitOfWork.SaveChanges();
                    return _mapper.Map<CreateLessonRespDTO>(lesson);
                }
                else throw new UserNotInCourseException();
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
                foreach (var userTopic in userTopics)
                {
                    if (userTopic.IsEnabled)
                    {
                        await _unitOfWork.LessonRepository.EnableLesson(userTopic.UserId, lessonId);
                    }
                    if (_unitOfWork.LessonRepository.IsVisible(userTopic.UserId, lessonId))
                        userTopic.LessonsActive++;

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

        public async Task<IEnumerable<GetLessonBriefDTO>> GetLessonsInCourse(long courseId, LessonFilter filter)
        {
            if (await _unitOfWork.CourseRepository.IsEnrolled(courseId))
            {
                var courseLessons = await _unitOfWork.LessonRepository.GetLessonsFromCourse(courseId, filter);
                return _mapper.Map<List<GetLessonBriefDTO>>(courseLessons);
            }
            throw new UserNotInCourseException();
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

        public async Task ChangeFeedback(long courseId, long lessonId, LessonFeedbackDTO feedbackDTO)
        {
            if (await _unitOfWork.CourseRepository.IsEnrolled(courseId))
            {
                var lesson = await _unitOfWork.LessonRepository.GetById(lessonId);
                if (lesson != null)
                {
                    if (lesson.CourseId == courseId)
                    {
                        var feedback = await _unitOfWork.LessonRepository.GetFeedback(lessonId);
                        if (feedback == null)
                        {
                            LessonFeedback newFeedback = new LessonFeedback();
                            if (feedbackDTO.State != null)
                            {
                                newFeedback.State = feedbackDTO.State;
                            }
                            if (feedbackDTO.Text != null)
                            {
                                newFeedback.Text = feedbackDTO.Text;
                            }
                            await _unitOfWork.LessonRepository.AddFeedback(lessonId, newFeedback);
                        }
                        else
                        {
                            if (feedbackDTO.State != null)
                            {
                                feedback.State = feedbackDTO.State;
                            }
                            if (feedbackDTO.Text != null)
                            {
                                feedback.Text = feedbackDTO.Text;
                            }
                        }
                        
                        _unitOfWork.SaveChanges();
                    }
                    else throw new InvalidIDException("No such lesson in this course.");
                }
                else throw new InvalidIDException("Lesson does not exist.");
            }
            else throw new UserNotInCourseException();
        }

        public async Task ModifyLessonStatus(long courseId, long lessonId, LessonStatusDTO lessonStatusDTO)
        {
            var lesson = await _unitOfWork.LessonRepository.GetById(lessonId);
            if (lesson != null && lesson.CourseId == courseId)
            {
                if (lessonStatusDTO.Visible != null)
                {
                    if (lessonStatusDTO.Visible == true)
                    {
                        await EnableLesson(lessonId);
                    }
                    else await DisableLesson(lessonId);
                }
                if (lessonStatusDTO.Favorite != null)
                {
                    await _unitOfWork.LessonRepository.SetFavorite(lessonId, (bool)lessonStatusDTO.Favorite);
                }
                _unitOfWork.SaveChanges();
            }
            else throw new InvalidIDException("No such lesson in this course.");

        }

        public async Task DeleteCustomLesson(long courseId, long lessonId)
        {
            var lesson = await _unitOfWork.LessonRepository.GetById(lessonId);
            if (lesson != null && lesson.CourseId == courseId)
            {
                await _unitOfWork.LessonRepository.DeleteCustom(lessonId);
                _unitOfWork.SaveChanges();
            }
            else throw new InvalidIDException("No such lesson in this course.");
        }

        public async Task<GetLessonDTO> GetLesson(long courseId, long lessonId)
        {
            if (await _unitOfWork.CourseRepository.IsEnrolled(courseId))
            {
                var lesson = await _unitOfWork.LessonRepository.GetForUser(lessonId);
                if (lesson != null)
                {
                    if (lesson.CourseId == courseId)
                    {
                        var lessonDTO = _mapper.Map<GetLessonDTO>(lesson);
                        if (_unitOfWork.LessonRepository.IsVisibleToSelf(lessonId))
                            lessonDTO.Visible = true;

                        if (_unitOfWork.LessonRepository.IsFavorite(lessonId))
                            lessonDTO.Favorite = true;

                        var feedback = await _unitOfWork.LessonRepository.GetFeedback(lessonId);
                        if (feedback != null)
                        {
                            lessonDTO.Feedback = _mapper.Map<LessonFeedbackDTO>(feedback);
                        }
                        return lessonDTO;
                    }
                    else throw new InvalidIDException("No such lesson in this course.");
                }
                else throw new InvalidIDException("Lesson does not exist.");
            }
            else throw new UserNotInCourseException();
        }

       
    }
}
