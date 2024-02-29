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

    public class CreateReadAloudExerciseDTO : CreateExerciseDTO
    {
        [Required]
        public string? TextL2 { get; set; }
        public string? ImageURL { get; set; }
    }

}
