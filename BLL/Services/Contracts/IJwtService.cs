using DAL.Entities;

namespace BLL.Services.Contracts
{
    public interface IJwtService
    {
        string CreateAccessToken(User user, IList<string> roles);
        string CreateRefreshToken();
    }
}