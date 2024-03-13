using AutoMapper;
using BLL.DTO.Users;
using BLL.Services.Contracts;
using DAL.Entities;
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

        public GetUserRespDTO GetUser()
        {
            var user = _unitOfWork.UserRepository.GetUser();
            ResetStreak(user);

            return _mapper.Map<GetUserRespDTO>(user);
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
            var user = _unitOfWork.UserRepository.GetUser();
            return _mapper.Map<GetUserSettingsDTO>(user);
        }

        public GetUserSettingsDTO ChangeSettings(ChangeUserSettingsDTO changeSettingsDTO)
        {
            var user = _unitOfWork.UserRepository.GetUser();
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
    }
}
