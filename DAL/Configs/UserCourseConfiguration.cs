using DAL.Entities;
using DAL.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace DAL.Configs
{
    public class UserCourseConfiguration : IEntityTypeConfiguration<UserCourse>
    {
        public void Configure(EntityTypeBuilder<UserCourse> builder)
        {
            builder
            .HasOne(uc => uc.SelectedLesson)
            .WithMany()
            .HasForeignKey(uc => uc.SelectedLessonId)
            .IsRequired(false);
        }
    }
}
