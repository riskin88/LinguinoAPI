using DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace DAL.Repositories.Contracts
{
    public interface IUserRepository
    {
        User GetUser();
        Task Follow(string userId);
        Task Unfollow(string userId);
        Task<IEnumerable<User>> GetFollowing(string userId);
        Task<bool> IsFollowed(string userId);
        Task<IEnumerable<User>> GetFollowers(string userId);
    }
}