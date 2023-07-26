using AutoMapper;
using BLL.DTO;
using DAL.Entities;


namespace BLL.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<User, CreateUserRespDTO>();
            CreateMap<User, GetUserRespDTO>();   
        }
    }
}
