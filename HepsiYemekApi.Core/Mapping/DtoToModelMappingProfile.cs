using AutoMapper;
using HepsiYemekApi.Dto;
using HepsiYemekApi.Entitiy;
using HepsiYemekApi.WebApi.Models;

namespace HepsiYemekApi.Core.Mapping
{
    public class DtoToModelMappingProfile : Profile
    {
        public DtoToModelMappingProfile()
        {
            CreateMap<CategoryDto, CategoryModel>().ReverseMap();
            CreateMap<CategoryDto, CategoryAddModel>().ReverseMap();
            CreateMap<ProductDto, ProductModel>().ReverseMap();
            CreateMap<ProductDto, ProductUpdateModel>().ReverseMap();
            CreateMap<ProductDto, ProductsAddModel>().ReverseMap();
        }
    }
}