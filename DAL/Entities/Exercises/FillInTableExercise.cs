﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class FillInTableExercise : Exercise
    {
        [Required]
        public string? QuestionL2 { get; set; }
        public string[][] TableRows { get; set; }
        public int[][] BlankCellCoords { get; set; }
    }
}
