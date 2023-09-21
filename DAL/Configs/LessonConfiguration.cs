using DAL.Entities;
using DAL.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasMany(l => l.Users)
            .WithMany(u => u.Lessons)
            .UsingEntity<UserLesson>(l => l.HasOne<User>(e => e.User).WithMany(e => e.UserLessons), r => r.HasOne<Lesson>(e => e.Lesson).WithMany(e => e.UserLessons));
            builder.HasMany(l => l.Topics)
            .WithMany(t => t.Lessons)
            .UsingEntity<TopicLesson>(l => l.HasOne<Topic>(e => e.Topic).WithMany(e => e.TopicLessons), r => r.HasOne<Lesson>(e => e.Lesson).WithMany(e => e.TopicLessons));
            builder.HasMany(l => l.LessonItems)
            .WithMany(i => i.Lessons)
            .UsingEntity<LessonItemLesson>();
            builder.HasOne(l => l.Author)
            .WithMany(a => a.LessonsCreated)
            .HasForeignKey(l => l.AuthorId);
        }
    }
}
