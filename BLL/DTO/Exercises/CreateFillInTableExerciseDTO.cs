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
    [AutoMap(typeof(FillInTableExercise), ReverseMap = true)]

    public class CreateFillInTableExerciseDTO
    {
        public double? OrderInItem { get; set; }
        public long EstimatedTimeMs { get; set; }
        [Required]
        public string? Question { get; set; }
        public string[][] TableRows { get; set; }
        public int[][] BlankCellCoords { get; set; }
    }

}
