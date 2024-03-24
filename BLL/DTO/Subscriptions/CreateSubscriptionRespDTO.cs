using AutoMapper;
using DAL.Entities;
using DAL.Entities.Enums;

namespace BLL.DTO.Subscriptions
{
    public class CreateSubscriptionRespDTO
    {
        public string? Type { get; set; }
        public string? ClientSecret { get; set; }
    }
}
