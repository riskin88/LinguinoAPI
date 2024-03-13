using AutoMapper;
using AutoMapper.Configuration.Annotations;
using DAL.Entities;

namespace BLL.DTO.Users
{

    public class ChangeUserSettingsDTO
    {
        public string? Name { get; set; }
        public string? Username { get; set; }
        public long? DailyGoal { get; set; }
    }
}
