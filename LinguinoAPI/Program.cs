using DAL.Data;
using DAL.Repositories.Contracts;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using BLL.Services.Contracts;
using BLL.Services;
using DAL.UnitOfWork;
using LinguinoAPI.DependencyInjection;
using LinguinoAPI.Filters;
using LinguinoAPI.Middleware;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL_DB")));

builder.Services.AddCustomServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
/*var configuration = new MapperConfiguration(cfg =>
    cfg.AddMaps(new[] {
        "Foo.UI",
        "Foo.Core"
    });
);*/

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
