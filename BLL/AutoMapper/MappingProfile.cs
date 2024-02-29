using AutoMapper;
using BLL.DTO.Exercises.Inbound;
using BLL.DTO.Exercises.Outbound;
using DAL.Entities;
using Microsoft.AspNetCore.Rewrite;
using System.Drawing;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Exercise, GetExerciseDTO>()
            .IncludeAllDerived()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.GetType().Name));

        CreateMap<BuildWordExercise, GetBuildWordExerciseDTO>();
        CreateMap<FillInSentenceExercise, GetFillInSentenceExerciseDTO>();
        CreateMap<FillInTableExercise, GetFillInTableExerciseDTO>();
        CreateMap<ListeningExercise, GetListeningExerciseDTO>();
        CreateMap<ReadAloudExercise, GetReadAloudExerciseDTO>();
        CreateMap<ReadingExercise, GetReadingExerciseDTO>();
        CreateMap<RepeatAudioExercise, GetRepeatAudioExerciseDTO>();
        CreateMap<ShortListeningExercise, GetShortListeningExerciseDTO>();
        CreateMap<SpeechExercise, GetSpeechExerciseDTO>();
        CreateMap<TextExercise, GetTextExerciseDTO>();

        CreateMap<CreateExerciseDTO, Exercise>()
            .IncludeAllDerived();

        CreateMap<CreateBuildWordExerciseDTO, BuildWordExercise>();
        CreateMap<CreateFillInSentenceExerciseDTO, FillInSentenceExercise>();
        CreateMap<CreateFillInTableExerciseDTO, FillInTableExercise>();
        CreateMap<CreateListeningExerciseDTO, ListeningExercise>();
        CreateMap<CreateReadAloudExerciseDTO, ReadAloudExercise>();
        CreateMap<CreateReadingExerciseDTO, ReadingExercise>();
        CreateMap<CreateRepeatAudioExerciseDTO, RepeatAudioExercise>();
        CreateMap<CreateShortListeningExerciseDTO, ShortListeningExercise>();
        CreateMap<CreateSpeechExerciseDTO, SpeechExercise>();
        CreateMap<CreateTextExerciseDTO, TextExercise>();
    }
}