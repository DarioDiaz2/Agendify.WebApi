using Agendify.Application.Dtos.SaleDetail;
using Agendify.Entities;
using AutoMapper;

namespace Agendify.WebApi.Mapping
{
    public class SaleDetailMappingProfile:Profile
    {
        public SaleDetailMappingProfile()
        {
            CreateMap<SaleDetail, SaleDetailResponseDto>()

                .ForMember(dest => dest.Quantity,
                    ori => ori.MapFrom(src => src.Quantity))

                .ForMember(dest => dest.UnitPrice,
                    ori => ori.MapFrom(src => src.UnitPrice))

                .ForMember(dest => dest.SubTotal,
                    ori => ori.MapFrom(src => src.SubTotal));

            CreateMap<SaleDetailRequestDto, SaleDetail>();
        }
    }
}
