﻿using AutoMapper;
using DAL.Entities;

namespace BLL.DTO
{
    [AutoMap(typeof(Word))]
    public class CreateWordRespDTO
    {
        public long Id { get; set; }
        public string? NameL1 { get; set; }
        public string? NameL2 { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public string? AudioURL { get; set; }
    }
}
