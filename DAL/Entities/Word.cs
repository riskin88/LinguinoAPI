﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Word : LessonItem
    {
        [Required]
        public string? NameL1 {  get; set; }
        [Required]
        public string? NameL2 { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? AudioUrl { get; set; }
        public List<WordExample> Examples { get; set; } = new();
    }
}
