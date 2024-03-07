﻿using AutoMapper.Configuration.Annotations;
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

    public class CreateListeningExerciseDTO : CreateExerciseDTO
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
