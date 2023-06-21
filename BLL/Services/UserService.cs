using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.Services.Contracts;
using DAL.Models;
using DAL.Repositories.Contracts;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;   
        }
        public async Task<User> GetUserAsync(Guid id)
        {
            return await _repository.GetById(id);
        }

        public Guid CreateUser(User user)
        {
            _repository.Add(user);
            //save
            return user.Id;
        }
    }
}
