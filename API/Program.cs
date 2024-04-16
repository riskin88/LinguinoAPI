using DAL.Data;
using DAL.Repositories.Contracts;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using BLL.Services.Contracts;
using BLL.Services;
using DAL.UnitOfWork;
using LinguinoAPI.DependencyInjection;
using LinguinoAPI.Middleware;
using AutoMapper;
using Microsoft.OpenApi.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration.GetConnectionString("MSSQL_DB");

builder.Services.AddDbContext<DataContext>(o => o.UseSqlServer(connection, o => o.EnableRetryOnFailure()));

builder.Services.AddCustomServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var MyAllowFrontendOrigins = "_myAllowFrontendOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowFrontendOrigins,
                      builda =>
                      {
                          builda.WithOrigins(builder.Configuration["FrontendUrl"]);
                      });
});

var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
    context.Database.Migrate();
}
    
app.UseSwagger();
app.UseSwaggerUI();

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
    app.UseCors(MyAllowFrontendOrigins);
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
