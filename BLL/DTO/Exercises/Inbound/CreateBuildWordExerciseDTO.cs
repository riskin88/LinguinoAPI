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
    public class CreateBuildWordExerciseDTO : CreateExerciseDTO
    {
        [Required]
        public string? WordL1 { get; set; }
        [Required]
        public string? WordL2 { get; set; }
        public string[] Letters { get; set; }
        public string? ImageURL { get; set; }
        public string? WordL2AudioURL { get; set; }
    }

}
