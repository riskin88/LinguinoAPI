using DAL.Entities;
using DAL.Filters;
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
        UserManager<User> UserManager { get; set; }
        IUserRepository UserRepository { get; set; }
        ICourseRepository CourseRepository { get; set; }
        ITopicRepository TopicRepository { get; set; }
        ILessonItemRepository LessonItemRepository { get; set; }
        ILessonRepository LessonRepository { get; set; }
        IExerciseRepository ExerciseRepository { get; set; }
        ILearningStepRepository LearningStepRepository { get; set; }

        public void SaveChanges();
    }
}
