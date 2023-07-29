using AutoMapper;
using BLL.Services.Contracts;
using DAL.Entities;
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
            _mapper = mapper;        }

        public void CreateCourse(Course createCourseDTO)
        {
            _unitOfWork.CourseRepository.Add(createCourseDTO);
            _unitOfWork.SaveChanges();
        }
        public async Task<IEnumerable<Course>> GetCourses(CourseFilter filter)
        {
            return await _unitOfWork.CourseRepository.FindByFilter(filter);
        }

        public async Task<IEnumerable<Course>> GetUserCourses(string id)
        {
            return await _unitOfWork.CourseRepository.GetOwn(id);
        }
    }
}
