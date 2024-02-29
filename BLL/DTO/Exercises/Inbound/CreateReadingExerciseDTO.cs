using AutoMapper.Configuration.Annotations;
using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.Exercises.Inbound
{

    public class CreateReadingExerciseDTO : CreateExerciseDTO
    {
        [Required]
        public string? Article { get; set; }
        [Required]
        public string? QuestionL2 { get; set; }
        [Required]
        public string? AnswerL2 { get; set; }
        public string? ImageURL { get; set; }
    }

}
