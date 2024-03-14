using AutoMapper;
using BLL.DTO.LessonItems;
using BLL.DTO.Users;
using BLL.Services.Contracts;
using DAL.Entities;
using DAL.Exceptions;
using DAL.Filters;
using DAL.Identity;
using DAL.UnitOfWork;
using System.Runtime.InteropServices;

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

        public async Task FollowUser(string userId)
        {
            await _unitOfWork.UserRepository.Follow(userId);
            _unitOfWork.SaveChanges();
        }

        public async Task UnfollowUser(string userId)
        {
            await _unitOfWork.UserRepository.Unfollow(userId);
            _unitOfWork.SaveChanges();
        }

        public async Task<GetUserDTO> GetUser()
        {
            var user = _unitOfWork.UserRepository.GetCurrentUser();
            ResetStreak(user);

            var userDTO = _mapper.Map<GetUserDTO>(user);
            userDTO.Role = (await _unitOfWork.UserManager.GetRolesAsync(user)).FirstOrDefault();
            return userDTO;
        }

        public async Task<IEnumerable<GetFollowerDTO>> GetFollowing(string userId)
        {
            var users = await _unitOfWork.UserRepository.GetFollowing(userId);
            var usersDTO = _mapper.Map<List<GetFollowerDTO>>(users);
            foreach (var user in usersDTO)
            {
                if (await _unitOfWork.UserRepository.IsFollowed(user.Id))
                    user.IsFollowed = true;
            }
            return usersDTO;
        }

        public async Task<IEnumerable<GetFollowerDTO>> GetFollowers(string userId)
        {
            var users = await _unitOfWork.UserRepository.GetFollowers(userId);
            var usersDTO = _mapper.Map<List<GetFollowerDTO>>(users);
            foreach (var user in usersDTO)
            {
                if (await _unitOfWork.UserRepository.IsFollowed(user.Id))
                    user.IsFollowed = true;
            }
            return usersDTO;
        }

        private void ResetStreak(User user)
        {
            if (user.LastSessionDate != null)
            {
                if (DateTime.Today > user.LastSessionDate.Value.AddDays(1))
                    user.Streak = 0;
            }
            _unitOfWork.SaveChanges();

        }

        public GetUserSettingsDTO GetSettings()
        {
            var user = _unitOfWork.UserRepository.GetCurrentUser();
            return _mapper.Map<GetUserSettingsDTO>(user);
        }

        public GetUserSettingsDTO ChangeSettings(ChangeUserSettingsDTO changeSettingsDTO)
        {
            var user = _unitOfWork.UserRepository.GetCurrentUser();
            if (changeSettingsDTO.Username != null)
            {
                user.UserName = changeSettingsDTO.Username;
            }

            if (changeSettingsDTO.Name != null)
            {
                user.Name = changeSettingsDTO.Name;
            }

            if (changeSettingsDTO.DailyGoal != null)
            {
                user.DailyGoalMs = changeSettingsDTO.DailyGoal;
            }

            _unitOfWork.SaveChanges();
            return _mapper.Map<GetUserSettingsDTO>(user);
        }

        public async Task<IEnumerable<GetUserBriefDTO>> GetUsers(UserFilter filter)
        {
            var users = await _unitOfWork.UserRepository.GetUsers(filter);
            var usersDTO = _mapper.Map<List<GetUserBriefDTO>>(users);
            foreach (var user in usersDTO)
            {
                if (await _unitOfWork.UserRepository.IsFollowed(user.Id))
                    user.IsFollowed = true;
            }
            return usersDTO;
        }

        public async Task<GetUserPublicDTO> GetUserPublicData(string userId)
        {
            var user = await _unitOfWork.UserRepository.GetUserWithStatsAndFollowers(userId);
            if (user != null)
            {
                var userDTO = _mapper.Map<GetUserPublicDTO>(user);
                if (await _unitOfWork.UserRepository.IsFollowed(user.Id))
                    userDTO.IsFollowed = true;
                userDTO.Followers = user.Followers.Count;
                userDTO.Following = user.Following.Count;
                return userDTO;
            }
            else throw new InvalidIDException("User does not exist.");
        }
    }
}
