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
    public class GetSpeechExerciseDTO : GetExerciseDTO
    {
        public string? AssignmentTopicL2 { get; set; }
        public int TimeMs { get; set; }
        public string[] Questions { get; set; }
    }

}
