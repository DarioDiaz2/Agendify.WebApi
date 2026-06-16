using Agendify.Application.Dtos.Product;
using Agendify.Entities;
using AutoMapper;

namespace Agendify.WebApi.Mapping
{
    public class ProductMappingProfile:Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductResponseDto>()
               .ForMember(dest => dest.Name,
                   ori => ori.MapFrom(src => src.Name))

               .ForMember(dest => dest.Price,
                   ori => ori.MapFrom(src => src.Price))

               .ForMember(dest => dest.Stock,
                   ori => ori.MapFrom(src => src.Stock))

               .ForMember(dest => dest.Active,
                   ori => ori.MapFrom(src => src.Active));

                CreateMap<ProductRequestDto, Product>();
        }
    }
}
