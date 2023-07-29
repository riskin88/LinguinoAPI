using AutoMapper;
using BLL.DTO;
using BLL.Services.Contracts;
using DAL.Identity;
using DAL.UnitOfWork;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public GetUserRespDTO GetUser()
        {
            var user = _unitOfWork.UserRepository.GetUser();
            return _mapper.Map<GetUserRespDTO>(user);
        }

    }
}
