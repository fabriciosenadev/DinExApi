using AutoMapper;
using DinExApi.API.DTO;
using DinExApi.Domain.Models;

namespace DinExApi.API.Configurations.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
