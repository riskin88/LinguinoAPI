using DAL.Entities;
using DAL.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>, IEntityTypeConfiguration<TextExercise>, IEntityTypeConfiguration<FillInBlankExercise>, IEntityTypeConfiguration<FillInBlankOptionsExercise>, IEntityTypeConfiguration<FillInTableExercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
        }
        public void Configure(EntityTypeBuilder<TextExercise> builder)
        { }
        public void Configure(EntityTypeBuilder<FillInBlankExercise> builder)
        {
            builder.Property(e => e.BlankIndexes)
            .HasConversion(
                v => string.Join(',', v),
                v => Array.ConvertAll((v.Split(',', StringSplitOptions.RemoveEmptyEntries)), int.Parse));
        }
        public void Configure(EntityTypeBuilder<FillInBlankOptionsExercise> builder)
        {
            builder.Property(e => e.BlankIndexes)
            .HasConversion(
                v => string.Join(',', v),
                v => Array.ConvertAll((v.Split(',', StringSplitOptions.RemoveEmptyEntries)), int.Parse));
            builder.Property(e => e.Options)
            .HasConversion(
                v => string.Join(',', v),
                v => (v.Split(',', StringSplitOptions.RemoveEmptyEntries)));
        }
        public void Configure(EntityTypeBuilder<FillInTableExercise> builder)
        {
            builder.Property(e => e.TableRows)
            .HasConversion(
                v => string.Join("|", v.Select(array => string.Join(",", array))),
                v => v.Split('|', StringSplitOptions.RemoveEmptyEntries).Select(substring => substring.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToArray());
            builder.Property(e => e.BlankCellCoords)
            .HasConversion(
                v => string.Join("|", v.Select(array => string.Join(",", array))),
                v => v.Split('|', StringSplitOptions.RemoveEmptyEntries).Select(substring => substring.Split(',', StringSplitOptions.RemoveEmptyEntries)).ToArray().Select(innerArray => innerArray.Select(int.Parse).ToArray()).ToArray());
        }
    }
}
