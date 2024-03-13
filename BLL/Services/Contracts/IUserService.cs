﻿using BLL.DTO.Users;

namespace BLL.Services.Contracts
{
    public interface IUserService
    {
        Task FollowUser(string userId);
        Task UnfollowUser(string userId);
        GetUserRespDTO GetUser();
        Task<IEnumerable<GetFollowerDTO>> GetFollowing(string userId);
        Task<IEnumerable<GetFollowerDTO>> GetFollowers(string userId);
        GetUserSettingsDTO GetSettings();
        GetUserSettingsDTO ChangeSettings(ChangeUserSettingsDTO changeSettingsDTO);
    }
}