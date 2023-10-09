using DAL.Entities;
using DAL.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class LessonItemConfiguration : IEntityTypeConfiguration<LessonItem>, IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<LessonItem> builder)
        {
            builder.HasMany(l => l.Users)
            .WithMany(u => u.LessonItems)
            .UsingEntity<UserLessonItem>(l => l.HasOne<User>(e => e.User).WithMany(e => e.UserLessonItems), r => r.HasOne<LessonItem>(e => e.LessonItem).WithMany(e => e.UserLessonItems));
        }
        public void Configure(EntityTypeBuilder<Word> builder)
        { }
    }
}
