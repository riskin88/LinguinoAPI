using DAL.Data;
using DAL.Entities;
using DAL.Identity;
using DAL.Repositories;
using DAL.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;
        public UserManager<User> UserManager { get; set; }
        public IUserRepository UserRepository { get; set; }
        public ICourseRepository CourseRepository { get; set; }
        public ITopicRepository TopicRepository { get; set; }

        public UnitOfWork(DataContext db, UserManager<User> userManager, IRoleGuard roleGuard)
        {
            _dbContext = db;
            UserManager = userManager;
            UserRepository = new UserRepository(roleGuard);
            CourseRepository = new CourseRepository(db, roleGuard);
            TopicRepository = new TopicRepository(db, roleGuard);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
