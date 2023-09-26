using AutoMapper;
using BLL.DTO;
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
            _unitOfWork.SaveChanges();

        }

        public async Task<IEnumerable<CourseRespDTO>> GetCourses(CourseFilter filter)
        {
            var res = await _unitOfWork.CourseRepository.FindByFilter(filter);
            List<CourseRespDTO> resp = new();
            foreach (var course in res)
            {
                resp.Add(_mapper.Map<CourseRespDTO>(course));
            }
            return resp;
        }

        public async Task<IEnumerable<CourseRespDTO>> GetUserCourses(string id)
        {
            var res = await _unitOfWork.CourseRepository.GetOwn(id);
            List<CourseRespDTO> resp = new();
            foreach (var course in res)
            {
                resp.Add(_mapper.Map<CourseRespDTO>(course));
            }
            return resp;
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

        public async Task<CourseRespDTO> AddUserWithTopics(AddCourseDTO courseDTO, long courseId, string userId)
        {
            var course = await _unitOfWork.CourseRepository.AddUser(courseId, userId);
            await _unitOfWork.CourseRepository.InitAllInCourse(courseId);
            _unitOfWork.SaveChanges();
            var defaultTopics = await _unitOfWork.CourseRepository.GetDefaultTopics(courseId);
            foreach (var topic in defaultTopics)
            {
                await AddUserToTopic(topic.Id, userId);
            }
            foreach (var topicDTO in courseDTO.SelectedTopics)
            {
                var topic = await _unitOfWork.TopicRepository.GetWithCourse(topicDTO.Id);
                if (topic != null && topic.CourseId == course.Id)
                    await AddUserToTopic(topic.Id, userId);
                else throw new InvalidIDException("Topic " + topicDTO.Id + " does not exist in this course.");
            }
            _unitOfWork.SaveChanges();
            return _mapper.Map<CourseRespDTO>(course);
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

        public async Task<TopicRespDTO> EnableTopic(string userId, long courseId, long topicId)
        {
            var topic = await _unitOfWork.TopicRepository.GetById(topicId);
            if (topic != null)
            {
                if (topic.CourseId == courseId)
                {
                    if (await _unitOfWork.CourseRepository.IsEnrolled(courseId))
                    {
                        await AddUserToTopic(topicId, userId);
                        _unitOfWork.SaveChanges();

                        var resp = _mapper.Map<TopicRespDTO>(topic);
                        resp.Enabled = true;
                        return resp;
                    }
                    else throw new InvalidIDException("There is no such course registered for this user.");
                }
                else throw new InvalidIDException("There is no such topic in this course.");
            }
            else throw new InvalidIDException("Topic " + topicId + " does not exist.");
        }

        public async Task DisableTopic(string userId, long courseId, long topicId)
        {
            var topic = await _unitOfWork.TopicRepository.GetById(topicId);
            if (topic != null)
            {
                if (topic.CourseId == courseId)
                {
                    if (await _unitOfWork.CourseRepository.IsEnrolled(courseId))
                    {
                        await RemoveUserFromTopic(topicId, userId);
                        _unitOfWork.SaveChanges();
                    }
                    else throw new InvalidIDException("There is no such course registered for this user.");
                }
                else throw new InvalidIDException("There is no such topic in this course.");
            }
            else throw new InvalidIDException("Topic does not exist.");
        }

        private async Task AddUserToTopic(long topicId, string userId)
        {
            var userTopic = await _unitOfWork.TopicRepository.GetUserTopic(topicId, userId);
            userTopic.IsEnabled = true;
            userTopic.LessonsActive = userTopic.Topic.LessonsTotal;

            var userLessons = await _unitOfWork.TopicRepository.GetUserLessons(topicId, userId);
            foreach (var userLesson in userLessons)
            {
                    userLesson.IsVisible = true;
            }
        }

        private async Task RemoveUserFromTopic(long topicId, string userId)
        {
            var userTopic = await _unitOfWork.TopicRepository.GetUserTopic(topicId, userId);
            userTopic.IsEnabled = false;

            var userLessons = await _unitOfWork.TopicRepository.GetUserLessons(topicId, userId);
            foreach (var userLesson in userLessons)
            {
                var userTopics = await _unitOfWork.LessonRepository.GetUserTopics(userLesson.Lesson.Id, userId);
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
    }
}
