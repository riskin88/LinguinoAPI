using AutoMapper;
using DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    [AutoMap(typeof(Word), ReverseMap = true)]
    public class CreateWordDTO
    {
        [Required]
        public string? NameL1 { get; set; }
        [Required]
        public string? NameL2 { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? AudioUrl { get; set; }
        public List<CreateWordExampleDTO> Examples { get; set; }
    }
}
