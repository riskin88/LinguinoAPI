using DAL.Entities;
using DAL.Filters;
using Microsoft.AspNetCore.Identity;

namespace DAL.Repositories.Contracts
{
    public interface IUserRepository
    {
        User GetCurrentUser();
        Task<User?> GetUserWithStatsAndFollowers(string userId);
        Task<User?> GetUserWithStats(string userId);
        Task Follow(string userId);
        Task Unfollow(string userId);
        Task<IEnumerable<User>> GetFollowing(string userId);
        Task<bool> IsFollowed(string userId);
        Task<IEnumerable<User>> GetFollowers(string userId);
        Task<IEnumerable<User>> GetUsers(UserFilter filter);
    }
}