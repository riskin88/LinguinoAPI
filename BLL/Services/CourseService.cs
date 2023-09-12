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

        public async Task CreateTopic(long id, Topic createTopicDTO)
        {

            var course = await _unitOfWork.CourseRepository.GetById(id);
            if (course != null)
            {
                _unitOfWork.TopicRepository.Add(createTopicDTO);
                course.Topics.Add(createTopicDTO);
                _unitOfWork.SaveChanges();
            }
            else throw new InvalidIDException("Course does not exist.");
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

        public async Task<CourseRespDTO> AddUser(AddCourseDTO courseDTO, string userId)
        {
            var course = await _unitOfWork.CourseRepository.AddUser(courseDTO.CourseId, userId);
            List<long> ids = new();
            foreach (var e in courseDTO.SelectedTopics)
            {
                ids.Add(e.Id);
            }
            await _unitOfWork.TopicRepository.AddUserToMany(ids, userId);
            _unitOfWork.SaveChanges();
            return _mapper.Map<CourseRespDTO>(course);
        }
    }
}
