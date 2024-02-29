using DAL.Entities;
using DAL.Entities.Relations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>, IEntityTypeConfiguration<TextExercise>, IEntityTypeConfiguration<BuildWordExercise>, IEntityTypeConfiguration<FillInSentenceExercise>, IEntityTypeConfiguration<FillInTableExercise>, IEntityTypeConfiguration<ListeningExercise>, IEntityTypeConfiguration<ReadAloudExercise>, IEntityTypeConfiguration<ReadingExercise>, IEntityTypeConfiguration<RepeatAudioExercise>, IEntityTypeConfiguration<ShortListeningExercise>, IEntityTypeConfiguration<SpeechExercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasMany(e => e.LearningSteps)
            .WithMany(l => l.Exercises)
            .UsingEntity<LearningStepExercise>(l => l.HasOne<LearningStep>(e => e.LearningStep).WithMany(e => e.LearningStepExercises), r => r.HasOne<Exercise>(e => e.Exercise).WithMany(e => e.LearningStepExercises));
        }
        public void Configure(EntityTypeBuilder<TextExercise> builder)
        { }

        public void Configure(EntityTypeBuilder<FillInSentenceExercise> builder)
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

        public void Configure(EntityTypeBuilder<ReadAloudExercise> builder)
        { }

        public void Configure(EntityTypeBuilder<ListeningExercise> builder)
        { }

        public void Configure(EntityTypeBuilder<ReadingExercise> builder)
        {  }

        public void Configure(EntityTypeBuilder<ShortListeningExercise> builder)
        {  }

        public void Configure(EntityTypeBuilder<RepeatAudioExercise> builder)
        {  }

        public void Configure(EntityTypeBuilder<SpeechExercise> builder)
        {
            builder.Property(e => e.Questions)
            .HasConversion(
                v => string.Join(',', v),
                v => (v.Split(',', StringSplitOptions.RemoveEmptyEntries)));
        }

        public void Configure(EntityTypeBuilder<BuildWordExercise> builder)
        {
            builder.Property(e => e.Letters)
            .HasConversion(
                v => string.Join(',', v),
                v => (v.Split(',', StringSplitOptions.RemoveEmptyEntries)));
        }
    }
}
