﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class TextExercise : Exercise
    {
        [Required]
        public string? TextL1 { get; set; }
        [Required]
        public string? TextL2 { get; set; }
        public string? Explanation { get; set; }
        public string? ImageURL { get; set; }
        public string? TextL2AudioURL { get; set; }
    }
}
