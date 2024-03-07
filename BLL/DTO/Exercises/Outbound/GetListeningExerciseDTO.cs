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
    public class GetListeningExerciseDTO : GetExerciseDTO
    {
        public string? AudioUrl { get; set; }
        public string? QuestionL2 { get; set; }
        public string? AnswerL2 { get; set; }
        public string? ImageUrl { get; set; }
    }

}
