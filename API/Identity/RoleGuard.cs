using DAL.Entities;
using DAL.Identity;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace API.Identity
{
    public class RoleGuard : IRoleGuard
    {
        public User user { get; }
        public IList<string> roles { get; }
        public RoleGuard(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            if (httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var id = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                user = userManager.FindByIdAsync(id).Result;
                roles = userManager.GetRolesAsync(user).Result;
            }
        }
    }
}
