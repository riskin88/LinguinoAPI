﻿using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DAL.Entities.Relations;

namespace DAL.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "3cf4378a-3fca-45d5-8782-db69e9bd5259", Name = "USER", NormalizedName = "USER" }, new IdentityRole { Id = "d05744d9-00ed-4cb8-8224-eb1e4abf31ba", Name = "PREMIUM_USER", NormalizedName = "PREMIUM_USER" }, new IdentityRole { Id = "7521910b-749d-4fbd-bf8e-dfddb9aa4fd6", Name = "ADMIN", NormalizedName = "ADMIN" });

        }
        public DbSet<Following> Following { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<UserTopic> UserTopics { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<TopicLesson> TopicLessons { get; set; }
        public DbSet<UserLesson> UserLessons { get; set; }
        public DbSet<LessonItem> LessonItems { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<LessonItemLesson> LessonItemsLessons { get; set; }
        public DbSet<UserLessonItem> UserLessonItems { get; set; }
        public DbSet<LearningStep> LearningSteps { get; set; }
        public DbSet<LearningStepExercise> LearningStepExercises { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<TextExercise> TextExercises { get; set; }
        public DbSet<BuildWordExercise> BuildWordExercises { get; set; }
        public DbSet<FillInSentenceExercise> FillInSentenceExercises { get; set; }
        public DbSet<FillInTableExercise> FillInTableExercises { get; set; }
        public DbSet<ListeningExercise> ListeningExercises { get; set; }
        public DbSet<ReadAloudExercise> ReadAloudExercises { get; set; }
        public DbSet<ReadingExercise> ReadingExercises { get; set; }
        public DbSet<RepeatAudioExercise> RepeatAudioExercises { get; set; }
        public DbSet<ShortListeningExercise> ShortListeningExercise { get; set; }
        public DbSet<SpeechExercise> SpeechExercise { get; set; }
    }
}
