using BLL.DTO.Exercises.Outbound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BLL.DTO.Exercises.Inbound
{
    [JsonDerivedType(typeof(CreateBuildWordExerciseDTO))]
    [JsonDerivedType(typeof(CreateFillInSentenceExerciseDTO))]
    [JsonDerivedType(typeof(CreateFillInTableExerciseDTO))]
    [JsonDerivedType(typeof(CreateListeningExerciseDTO))]
    [JsonDerivedType(typeof(CreateReadAloudExerciseDTO))]
    [JsonDerivedType(typeof(CreateReadingExerciseDTO))]
    [JsonDerivedType(typeof(CreateRepeatAudioExerciseDTO))]
    [JsonDerivedType(typeof(CreateShortListeningExerciseDTO))]
    [JsonDerivedType(typeof(CreateSpeechExerciseDTO))]
    [JsonDerivedType(typeof(CreateTextExerciseDTO))]
    public class CreateExerciseDTO
    {
        public long EstimatedTimeMs { get; set; }
    }
}
