using Agendify.Application.Dtos.Sale;
using Agendify.Entities;
using AutoMapper;

namespace Agendify.WebApi.Mapping
{
    public class SaleMappingProfile:Profile
    {
        public SaleMappingProfile()
        {
            CreateMap<Sale, SaleResponseDto>()
                .ForMember(dest => dest.ClientId,
            ori => ori.MapFrom(src => src.ClientId))
            .ForMember(dest => dest.SaleDate,
                ori => ori.MapFrom(src => src.SaleDate))
            .ForMember(dest => dest.Total,
                ori => ori.MapFrom(src => src.Total));

            CreateMap<SaleRequestDto, Sale>();
        }
    }
}
