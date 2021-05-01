using AutoMapper;
using DinExApi.API.DTO;
using DinExApi.Domain.Models;

namespace DinExApi.API.Configurations.Profiles
{
    public class LaunchProfile : Profile
    {
        public LaunchProfile()
        {
            CreateMap<Launch, LaunchDTO>().ReverseMap();
        }
    }
}
