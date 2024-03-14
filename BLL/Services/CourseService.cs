using AutoMapper;
using BLL.DTO.Courses;
using BLL.DTO.Topics;
using BLL.Exceptions;
using BLL.Exceptions.Auth;
using BLL.Services.Contracts;
using DAL.Data;
using DAL.Entities;
using DAL.Exceptions;
using DAL.Filters;
using DAL.Identity;
using DAL.UnitOfWork;

namespace BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateCourse(Course createCourseDTO)
        {
            _unitOfWork.CourseRepository.Add(createCourseDTO);
            _unitOfWork.SaveChanges();
        }

        public async Task CreateTopic(long courseId, CreateTopicDTO createTopicDTO)
        {
            var topic = _mapper.Map<Topic>(createTopicDTO);
            _unitOfWork.TopicRepository.Add(topic);
            await _unitOfWork.CourseRepository.AddTopic(courseId, topic);
            // add record to the M:N join table
            var users = await _unitOfWork.CourseRepository.GetUsersWithTopics(courseId);
            foreach (var user in users)
            {
                user.Topics.Add(topic);
            }
            _unitOfWork.SaveChanges();

        }

        public async Task<IEnumerable<GetCourseDTO>> GetCourses(CourseFilter filter)
        {
            var res = await _unitOfWork.CourseRepository.FindByFilter(filter);
            return _mapper.Map<List<GetCourseDTO>>(res);
        }

        public async Task<IEnumerable<GetCourseDTO>> GetUserCourses()
        {
            var res = await _unitOfWork.CourseRepository.GetOwn();
            return _mapper.Map<List<GetCourseDTO>>(res);
        }

        public async Task<CourseWithFeaturedDTO> GetWithFeaturedTopics(long courseId)
        {
            var course = await _unitOfWork.CourseRepository.GetWithFeaturedTopics(courseId);
            if (course != null)
            {
                return _mapper.Map<CourseWithFeaturedDTO>(course);
            }
            else throw new InvalidIDException("Course does not exist.");
        }

        public async Task<GetCourseDTO> AddUserWithTopics(AddCourseDTO courseDTO, long courseId)
        {
            var course = await _unitOfWork.CourseRepository.AddUser(courseId);
            await InitAllInCourse(courseId);
            _unitOfWork.SaveChanges();
            var defaultTopics = await _unitOfWork.CourseRepository.GetDefaultTopics(courseId);
            foreach (var topic in defaultTopics)
            {
                await EnableTopic(topic.Id);
            }
            foreach (var topicDTO in courseDTO.SelectedTopics)
            {
                var topic = await _unitOfWork.TopicRepository.GetWithCourse(topicDTO.Id);
                if (topic != null && topic.CourseId == course.Id)
                    await EnableTopic(topic.Id);
                else throw new InvalidIDException("Topic " + topicDTO.Id + " does not exist in this course.");
            }
            _unitOfWork.SaveChanges();
            return _mapper.Map<GetCourseDTO>(course);
        }

        public async Task<IEnumerable<TopicRespDTO>> GetTopics(long courseId, TopicFilter filter)
        {
            var courseTopics = await _unitOfWork.CourseRepository.GetTopics(courseId, filter);
            List<TopicRespDTO> resp = new();
            foreach (var topic in courseTopics)
            {
                var tmp = _mapper.Map<TopicRespDTO>(topic);
                if (_unitOfWork.TopicRepository.IsEnabled(topic))
                    tmp.Enabled = true;
                resp.Add(tmp);
            }
            return resp;
        }

        public async Task EnableTopicInCourse(long courseId, long topicId)
        {
            var topic = await _unitOfWork.TopicRepository.GetById(topicId);
            if (topic != null)
            {
                if (topic.CourseId == courseId)
                {
                    if (await _unitOfWork.CourseRepository.IsEnrolled(courseId))
                    {
                        await EnableTopic(topicId);
                        _unitOfWork.SaveChanges();
                    }
                    else throw new UserNotInCourseException();
                }
                else throw new InvalidIDException("There is no such topic in this course.");
            }
            else throw new InvalidIDException("Topic " + topicId + " does not exist.");
        }

        public async Task DisableTopicInCourse(long courseId, long topicId)
        {
            var topic = await _unitOfWork.TopicRepository.GetById(topicId);
            if (topic != null)
            {
                if (topic.CourseId == courseId)
                {
                    if (await _unitOfWork.CourseRepository.IsEnrolled(courseId))
                    {
                        await DisableTopic(topicId);
                        _unitOfWork.SaveChanges();
                    }
                    else throw new UserNotInCourseException();
                }
                else throw new InvalidIDException("There is no such topic in this course.");
            }
            else throw new InvalidIDException("Topic does not exist.");
        }

        private async Task EnableTopic(long topicId)
        {
            var userTopic = await _unitOfWork.TopicRepository.GetUserTopic(topicId);
            userTopic.IsEnabled = true;
            userTopic.LessonsActive = userTopic.Topic.LessonsTotal;

            var userLessons = await _unitOfWork.TopicRepository.GetUserLessons(topicId);
            foreach (var userLesson in userLessons)
            {
                userLesson.IsVisible = true;
            }
        }

        private async Task DisableTopic(long topicId)
        {
            var userTopic = await _unitOfWork.TopicRepository.GetUserTopic(topicId);
            userTopic.IsEnabled = false;

            var userLessons = await _unitOfWork.TopicRepository.GetUserLessons(topicId);
            foreach (var userLesson in userLessons)
            {
                var userTopics = await _unitOfWork.LessonRepository.GetUserTopics(userLesson.Lesson.Id);
                bool hide = true;
                foreach (var ut in userTopics)
                {
                    if (ut.IsEnabled)
                    {
                        hide = false;
                        break;
                    }
                }
                if (hide)
                    userLesson.IsVisible = false;
            }
        }

        private async Task InitAllInCourse(long courseId)
        {
            var topics = await _unitOfWork.CourseRepository.GetTopics(courseId);
            foreach (var topic in topics)
            {

                await _unitOfWork.TopicRepository.AddToSelf(topic.Id);

            }
            var lessons = await _unitOfWork.CourseRepository.GetBuiltinLessons(courseId);
            foreach (var lesson in lessons)
            {

                await _unitOfWork.LessonRepository.AddToSelf(lesson.Id);

            }

        }

        public async Task SelectCourse(long courseId)
        {
            if (await _unitOfWork.CourseRepository.IsEnrolled(courseId))
            {
                await _unitOfWork.CourseRepository.SelectCourse(courseId);
                _unitOfWork.SaveChanges();
            }
            else throw new UserNotInCourseException();

        }
    }
}
