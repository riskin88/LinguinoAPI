using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Exceptions.Auth;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Exceptions;
using DAL.Filters;
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

        public async Task<CourseRespDTO> AddUserWithTopics(AddCourseDTO courseDTO, string userId)
        {
            var course = await _unitOfWork.CourseRepository.AddUser(courseDTO.CourseId, userId);
            _unitOfWork.SaveChanges();
            foreach (var topicDTO in courseDTO.SelectedTopics)
            {
                var topic = await _unitOfWork.TopicRepository.GetWithCourse(topicDTO.Id);
                if (topic != null && topic.CourseId == course.Id)
                    await _unitOfWork.TopicRepository.AddUserToOne(userId, topicDTO.Id);
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
                if (await _unitOfWork.TopicRepository.IsEnabled(topic.Id))
                    tmp.Enabled = true;
                resp.Add(tmp);
            }
            return resp;
        }

        public async Task<TopicRespDTO> ToggleTopic(string userId, long courseId, long topicId, ToggleTopicDTO topicDTO)
        {
            var topic = await _unitOfWork.TopicRepository.GetWithCourse(topicId);
            if (topic != null)
            {
                if (topic.CourseId == courseId)
                {
                    if (await _unitOfWork.CourseRepository.IsEnrolled(courseId))
                    {
                        if (topicDTO.Enabled)
                            await _unitOfWork.TopicRepository.AddUserToOne(userId, topicId);
                        else await _unitOfWork.TopicRepository.RemoveUserFromOne(userId, topicId);
                        _unitOfWork.SaveChanges();

                        var resp = _mapper.Map<TopicRespDTO>(topic);
                        if (await _unitOfWork.TopicRepository.IsEnabled(topicId))
                            resp.Enabled = true;
                        return resp;
                    }
                    else throw new InvalidIDException("There is no such course registered for this user.");
                }
                else throw new InvalidIDException("There is no such topic in this course.");
            }
            else throw new InvalidIDException("Topic does not exist.");

        }
    }
}
