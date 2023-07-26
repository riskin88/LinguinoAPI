using DAL.Entities;

namespace BLL.Services.Contracts
{
    public interface IJwtService
    {
        string CreateToken(User user, IList<string> roles);
    }
}