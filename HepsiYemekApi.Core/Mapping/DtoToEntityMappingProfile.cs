using AutoMapper;
using HepsiYemekApi.Dto;
using HepsiYemekApi.Entitiy;

namespace HepsiYemekApi.Core.Mapping
{
    public class DtoToEntityMappingProfile : Profile
    {
        public DtoToEntityMappingProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}