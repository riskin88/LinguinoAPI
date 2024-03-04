using DAL.Data;
using DAL.Entities;
using DAL.Filters;
using DAL.Identity;
using DAL.Repositories;
using DAL.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;
        public UserManager<User> UserManager { get; set; }
        public IUserRepository UserRepository { get; set; }
        public ICourseRepository CourseRepository { get; set; }
        public ITopicRepository TopicRepository { get; set; }
        public ILessonItemRepository LessonItemRepository { get; set; }
        public ILessonRepository LessonRepository { get; set; }
        public IExerciseRepository ExerciseRepository { get; set; }
        public ILearningStepRepository LearningStepRepository { get; set; }


        public UnitOfWork(DataContext db, UserManager<User> userManager, IRoleGuard roleGuard)
        {
            _dbContext = db;
            UserManager = userManager;
            UserRepository = new UserRepository(db, roleGuard);
            CourseRepository = new CourseRepository(db, roleGuard);
            TopicRepository = new TopicRepository(db, roleGuard);
            LessonItemRepository = new LessonItemRepository(db, roleGuard);
            LessonRepository = new LessonRepository(db, roleGuard);
            ExerciseRepository = new ExerciseRepository(db, roleGuard);
            LearningStepRepository = new LearningStepRepository(db);
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
