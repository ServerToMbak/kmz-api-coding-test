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

            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<EnvanterItem, EnvanterItemDTO>().ReverseMap();
            CreateMap<Envanter, EnvanterDTO>().ReverseMap();
            CreateMap<Product, ProductDetailDTO>()
                .ForMember(p=>p.EnvanterItems, src=> src.MapFrom(dest => dest.EnvanterItems));
        }
    }
}
