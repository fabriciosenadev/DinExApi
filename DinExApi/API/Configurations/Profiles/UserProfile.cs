using AutoMapper;
using DinExApi.API.DTO;
using DinExApi.Domain.Models;

namespace DinExApi.API.Configurations.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
