using AutoMapper;
using System.Data;
using Task.DTOs;
using Task.Entities;

namespace Task.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<Product, ProductDTO>()
                .ForMember( p => p.BrandName, src => src
                .MapFrom( dest => dest.Envanter.BrandName))
                .ReverseMap();

            CreateMap<Product, ProductDetailDTO>()
                .ForMember(p => p.StockQuantity, src => src.MapFrom( dest => dest.Envanter.QuantityInStock))
                .ForMember(p => p.BrandName, src => src.MapFrom(dest => dest.Envanter.BrandName))
                .ForMember(p => p.CategoryName, src=> src.MapFrom(dest => dest.Envanter.Category.Name));
        }
    }
}
