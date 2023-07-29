using DAL.Entities;
using DAL.Identity;
using DAL.Repositories.Contracts;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IRoleGuard _roleGuard;
        public UserRepository(IRoleGuard roleGuard)
        {
            _roleGuard = roleGuard;
        }
        public User GetUser()
        {
            return _roleGuard.user;
        }
    }
}
