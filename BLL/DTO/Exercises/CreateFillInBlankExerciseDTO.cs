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
    [AutoMap(typeof(FillInBlankExercise), ReverseMap = true)]

    public class CreateFillInBlankExerciseDTO
    {
        public double? OrderInItem { get; set; }
        public long EstimatedTimeMs { get; set; }
        [Required]
        public string? Question { get; set; }
        [Required]
        public string? Answer { get; set; }
        public int[] BlankIndexes { get; set; }
        public string? ImageURL { get; set; }
        public string? AnswerAudioURL { get; set; }
    }

}
