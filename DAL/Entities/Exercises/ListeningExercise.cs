﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class ListeningExercise : Exercise
    {
        [Required]
        public string? AudioUrl { get; set; }
        [Required]
        public string? QuestionL2 { get; set; }
        [Required]
        public string? AnswerL2 { get; set; }
        public string? ImageUrl { get; set; }
    }
}
