using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Repositories.Contracts;
using DAL.UnitOfWork;

namespace BLL.Services
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserAuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }
        public async Task<User> GetUserByIdAsync(long id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }

        public User RegisterUser(User user)
        {
            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.SaveChanges();
            // save
            return user;
        }
    }
}
