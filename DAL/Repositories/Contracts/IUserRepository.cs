using DAL.Entities;

namespace DAL.Repositories.Contracts
{
    public interface IUserRepository
    {
        public User GetUser();
    }
}
