using BLL.Services;
using BLL.Services.Contracts;
using DAL.UnitOfWork;

namespace LinguinoAPI.DependencyInjection
{
    public static class DI
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUserAuthService, UserAuthService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}
