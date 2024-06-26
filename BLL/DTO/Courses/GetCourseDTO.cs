﻿using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Courses
{
    [AutoMap(typeof(Course))]

    public class GetCourseDTO
    {
        public long Id { get; set; }
        public string? Language1 { get; set; }
        public string? Language2 { get; set; }
        public string? Name { get; set; }
        public string? ThumbnailUrl { get; set; }
    }
}
