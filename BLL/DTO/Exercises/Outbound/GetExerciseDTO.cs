using AutoMapper.Configuration.Annotations;
using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BLL.DTO.Exercises.Outbound
{
    [JsonDerivedType(typeof(GetBuildWordExerciseDTO))]
    [JsonDerivedType(typeof(GetFillInSentenceExerciseDTO))]
    [JsonDerivedType(typeof(GetFillInTableExerciseDTO))]
    [JsonDerivedType(typeof(GetListeningExerciseDTO))]
    [JsonDerivedType(typeof(GetReadAloudExerciseDTO))]
    [JsonDerivedType(typeof(GetReadingExerciseDTO))]
    [JsonDerivedType(typeof(GetRepeatAudioExerciseDTO))]
    [JsonDerivedType(typeof(GetShortListeningExerciseDTO))]
    [JsonDerivedType(typeof(GetSpeechExerciseDTO))]
    [JsonDerivedType(typeof(GetTextExerciseDTO))]
    public class GetExerciseDTO
    {
        public long Id { get; set; }
        public string? Type { get; set; }
        public long LessonItemId { get; set; }
        public bool IsNew { get; set; } = false;
        public long? LessonId { get; set; }
    }

}
