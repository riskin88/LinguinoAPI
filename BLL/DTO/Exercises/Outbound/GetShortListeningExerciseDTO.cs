﻿using AutoMapper.Configuration.Annotations;
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
    public class GetShortListeningExerciseDTO : GetExerciseDTO
    {
        public string? TextL2 { get; set; }
        public string? TextL2AudioUrl { get; set; }
    }

}
