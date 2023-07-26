using DAL.Data;
using DAL.Repositories;
using DAL.Repositories.Contracts;
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
        public IUserRepository UserRepository { get; set; }
        public ICourseRepository CourseRepository { get; set; }

        public UnitOfWork(DataContext db)
        {
            _dbContext = db;
            UserRepository = new UserRepository();
            CourseRepository = new CourseRepository(db);
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
