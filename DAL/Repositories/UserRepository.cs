using DAL.Data;
using DAL.Entities;
using DAL.Exceptions;
using DAL.Filters;
using DAL.Identity;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        private readonly IRoleGuard _roleGuard;
        public UserRepository(DataContext dataContext, IRoleGuard roleGuard)
        {
            _dataContext = dataContext;
            _roleGuard = roleGuard;
        }
        public User GetCurrentUser()
        {
            return _roleGuard.user;
        }

        public async Task Follow(string userId)
        {
            if (userId != _roleGuard.user.Id)
            {
                var userToFollow = await _dataContext.Set<User>().Include(u => u.Followers).FirstOrDefaultAsync(e => e.Id == userId);
                if (userToFollow != null)
                {
                    userToFollow.Followers.Add(_roleGuard.user);
                }
                else throw new InvalidIDException("User does not exist.");
            }
            else throw new InvalidIDException("You cannot follow yourself.");

        }

        public async Task Unfollow(string userId)
        {
            var userToUnfollow = await _dataContext.Set<User>().Include(u => u.Followers).FirstOrDefaultAsync(e => e.Id == userId);
            if (userToUnfollow != null)
            {
                userToUnfollow.Followers.Remove(_roleGuard.user);
            }
            else throw new InvalidIDException("User does not exist.");
        }

        public async Task<IEnumerable<User>> GetFollowing(string userId)
        {
            var user = await _dataContext.Set<User>().Include(u => u.Following).FirstOrDefaultAsync(e => e.Id == userId);
            if (user != null)
            {
                return user.Following;
            }
            else throw new InvalidIDException("User does not exist.");
        }

        public async Task<bool> IsFollowed(string userId)
        {
            var user = await _dataContext.Set<User>().Include(u => u.Followers).FirstOrDefaultAsync(e => e.Id == userId);
            if (user != null)
            {
                return user.Followers.Contains(_roleGuard.user);
            }
            else throw new InvalidIDException("User does not exist.");
        }

        public async Task<IEnumerable<User>> GetFollowers(string userId)
        {
            var user = await _dataContext.Set<User>().Include(u => u.Followers).FirstOrDefaultAsync(e => e.Id == userId);
            if (user != null)
            {
                return user.Followers;
            }
            else throw new InvalidIDException("User does not exist.");
        }

        public async Task<IEnumerable<User>> GetUsers(UserFilter filter)
        {
            return await _dataContext.Set<User>().Where(u => filter.SearchName == null || (u.Name != null && u.Name.Contains(filter.SearchName)) || (u.UserName != null && u.UserName.StartsWith(filter.SearchName))).ToListAsync();
        }

        public async Task<User?> GetUserWithStatsAndFollowers(string userId)
        {
            return await _dataContext.Set<User>().Include(u => u.Followers).Include(u => u.Following).Include(u => u.LearningStats.Where(ls => (DateTime.Now - ls.Date).TotalDays <= 7)).FirstOrDefaultAsync(e => e.Id == userId);
        }

        public async Task<User?> GetUserWithStats(string userId)
        {
            return await _dataContext.Set<User>().Include(u => u.LearningStats.Where(ls => (DateTime.Now - ls.Date).TotalDays <= 7)).FirstOrDefaultAsync(e => e.Id == userId);
        }
    }
}
