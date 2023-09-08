using DAL.Entities;
using DAL.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; set; }
        ICourseRepository CourseRepository { get; set; }
        ITopicRepository TopicRepository { get; set; }
        UserManager<User> UserManager { get; set; }

        public void SaveChanges();
    }
}
