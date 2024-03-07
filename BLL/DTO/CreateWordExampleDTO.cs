using AutoMapper;
using DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    [AutoMap(typeof(WordExample), ReverseMap = true)]
    public class CreateWordExampleDTO
    {
        [Required]
        public string? TextL1 { get; set; }
        [Required]
        public string? TextL2 { get; set; }
        public string? AudioUrl { get; set; }
    }
}
