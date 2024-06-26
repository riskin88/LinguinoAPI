﻿using BLL.Services;
using BLL.Services.Auth;
using BLL.Services.Contracts;
using DAL.Data;
using DAL.Entities;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BLL.Helpers;
using DAL.Identity;
using API.Identity;
using Microsoft.Extensions.Configuration;
using BLL.Config;

namespace LinguinoAPI.DependencyInjection
{
    public static class DI
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<DataContext>().
            AddDefaultTokenProviders();
            services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromHours(10));
            services
    .AddAuthentication(cfg =>
    {
        cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = configuration["SecuritySettings:Audience"],
            ValidIssuer = configuration["SecuritySettings:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["SecuritySettings:Key"])
            )
        };
    });
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.Configure<LearningSettings>(configuration.GetSection("LearningSettings"));
            services.Configure<SecuritySettings>(configuration.GetSection("SecuritySettings"));
            services.Configure<SubscriptionSettings>(configuration.GetSection("SubscriptionSettings"));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddScoped<IUserAuthService, UserAuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<ILessonItemService, LessonItemService>();
            services.AddScoped<IExerciseService, ExerciseService>();
            services.AddScoped<ILearningService, LearningService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();

            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<EmailHelper>();
            services.AddScoped<IRoleGuard, RoleGuard>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}
