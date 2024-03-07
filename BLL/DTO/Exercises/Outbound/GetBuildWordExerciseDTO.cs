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
    public class GetBuildWordExerciseDTO : GetExerciseDTO
    {
        public string? WordL1 { get; set; }
        public string? WordL2 { get; set; }
        public string[] Letters { get; set; }
        public string? ImageUrl { get; set; }
        public string? WordL2AudioUrl { get; set; }
    }

}
