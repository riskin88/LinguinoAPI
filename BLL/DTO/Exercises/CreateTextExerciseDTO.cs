using AutoMapper.Configuration.Annotations;
using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.Exercises
{
    [AutoMap(typeof(TextExercise), ReverseMap = true)]

    public class CreateTextExerciseDTO
    {
        public double? OrderInItem { get; set; }
        public long EstimatedTimeMs { get; set; }
        [Required]
        public string? Question { get; set; }
        [Required]
        public string? Answer { get; set; }
        public string? Explanation { get; set; }
        public string? ImageURL { get; set; }
        public string? AnswerAudioURL { get; set; }
    }

}
