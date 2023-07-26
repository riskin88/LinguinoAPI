using DAL.Entities;

namespace BLL.Services.Contracts
{
    public interface ICourseService
    {
        Task CreateCourse(Course createCourseDTO);
    }
}