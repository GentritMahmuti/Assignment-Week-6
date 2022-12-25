using Assignment_Week_6.Models.DTOs;
using Assignment_Week_6.Models.Entities;
using AutoMapper;

namespace Assignment_Week_6.Helpers
{
    public class AutoMapperConfigurations : Profile
    {
        public AutoMapperConfigurations()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();
        }
    }
}
