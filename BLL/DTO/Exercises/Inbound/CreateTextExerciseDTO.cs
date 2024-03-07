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
    public class CreateTextExerciseDTO : CreateExerciseDTO
    {
        [Required]
        public string? TextL1 { get; set; }
        [Required]
        public string? TextL2 { get; set; }
        public string? Explanation { get; set; }
        public string? ImageUrl { get; set; }
        public string? TextL2AudioUrl { get; set; }
    }

}
