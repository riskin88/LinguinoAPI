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
    public class GetFillInSentenceExerciseDTO : GetExerciseDTO
    {
        public string? TextL1 { get; set; }
        public string? TextL2 { get; set; }
        public int[] BlankIndexes { get; set; }
        public string[] Options { get; set; }
        public string? ImageUrl { get; set; }
    }

}
