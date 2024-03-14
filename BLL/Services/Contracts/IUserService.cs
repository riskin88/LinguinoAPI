using BLL.DTO.Users;
using DAL.Filters;

namespace BLL.Services.Contracts
{
    public interface IUserService
    {
        Task FollowUser(string userId);
        Task UnfollowUser(string userId);
        Task<GetUserDTO> GetUser();
        Task<IEnumerable<GetFollowerDTO>> GetFollowing(string userId);
        Task<IEnumerable<GetFollowerDTO>> GetFollowers(string userId);
        GetUserSettingsDTO GetSettings();
        GetUserSettingsDTO ChangeSettings(ChangeUserSettingsDTO changeSettingsDTO);
        Task<IEnumerable<GetUserBriefDTO>> GetUsers(UserFilter filter);
        Task<GetUserPublicDTO> GetUserPublicData(string userId);
    }
}