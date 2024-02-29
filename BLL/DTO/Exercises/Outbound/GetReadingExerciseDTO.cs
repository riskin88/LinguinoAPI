using AutoMapper.Configuration.Annotations;
using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO.Exercises.Outbound
{
    public class GetReadingExerciseDTO : GetExerciseDTO
    {
        public string? Article { get; set; }
        public string? QuestionL2 { get; set; }
        public string? AnswerL2 { get; set; }
        public string? ImageURL { get; set; }
    }

}
