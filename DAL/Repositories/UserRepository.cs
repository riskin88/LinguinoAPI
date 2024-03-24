using DAL.Data;
using DAL.Entities;
using DAL.Exceptions;
using DAL.Filters;
using DAL.Identity;
using DAL.Repositories.Contracts;
using Microsoft.AspNetCore.Builder;
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

        public async Task<User> GetCurrentUserWithCourse()
        {
            var userId = _roleGuard.user.Id;
            return await _dataContext.Set<User>().Include(u => u.SelectedCourse).FirstOrDefaultAsync(e => e.Id == userId);
        }

        public async Task<User> GetCurrentUserWithSubscription()
        {
            var userId = _roleGuard.user.Id;
            return await _dataContext.Set<User>().Include(u => u.Subscription).FirstOrDefaultAsync(e => e.Id == userId);
        }


        public async Task<User> GetUserByStripeSubscriptionId(string id)
        {
            var user = await _dataContext.Set<User>().Include(u => u.Subscription).Where(u => u.Subscription != null && u.Subscription.StripeSubscriptionId == id).FirstOrDefaultAsync();
            if (user != null)
            {
                return user;
            }
            else throw new SubscriptionErrorException("Unknown subscription ID.");
        }

        public async Task<User> GetUserWithCourse(string userId)
        {
            var user = await _dataContext.Set<User>().Include(u => u.SelectedCourse).FirstOrDefaultAsync(e => e.Id == userId);
            if (user != null)
            {
                return user;
            }
            else throw new InvalidIDException("User does not exist.");
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
            var weekAgo = DateTime.Today.AddDays(-7);
            return await _dataContext.Set<User>().Include(u => u.Followers).Include(u => u.Following).Include(u => u.LearningStats.Where(ls => ls.Date > weekAgo)).FirstOrDefaultAsync(e => e.Id == userId);
        }

        public async Task<User?> GetUserWithStats(string userId)
        {
            var weekAgo = DateTime.Today.AddDays(-7);
            return await _dataContext.Set<User>().Include(u => u.LearningStats.Where(ls => ls.Date > weekAgo)).FirstOrDefaultAsync(e => e.Id == userId);
        }

        public async Task<User?> GetUserByRefreshTokenHash(string refreshToken)
        {
            return await _dataContext.Set<User>().FirstOrDefaultAsync(e => e.RefreshToken == refreshToken);
        }

    }
}
