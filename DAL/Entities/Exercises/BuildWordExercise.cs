﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class BuildWordExercise : Exercise
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
