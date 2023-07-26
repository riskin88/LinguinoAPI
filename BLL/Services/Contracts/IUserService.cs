using BLL.DTO;

namespace BLL.Services.Contracts
{
    public interface IUserService
    {
        Task<GetUserRespDTO> GetUser();
    }
}