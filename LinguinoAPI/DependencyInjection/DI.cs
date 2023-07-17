using BLL.Services;
using BLL.Services.Contracts;
using DAL.Data;
using DAL.Entities;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace LinguinoAPI.DependencyInjection
{
    public static class DI
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddIdentityCore<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<DataContext>();

            services.AddScoped<IUserAuthService, UserAuthService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}
