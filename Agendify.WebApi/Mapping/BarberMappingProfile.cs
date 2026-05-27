using Agendify.Application.Dtos.Barber;
using Agendify.Entities;
using AutoMapper;

namespace Agendify.WebApi.Mapping
{
    public class BarberMappingProfile : Profile
    {
        public BarberMappingProfile()
        {
            CreateMap<Barber, BarberResponseDto>()
                .ForMember(dest => dest.FullName,
                    ori => ori.MapFrom(src => src.FullName))

                .ForMember(dest => dest.Specialty,
                    ori => ori.MapFrom(src => src.Specialty))

                .ForMember(dest => dest.Phone,
                    ori => ori.MapFrom(src => src.Phone))

                .ForMember(dest => dest.Active,
                    ori => ori.MapFrom(src => src.Active));

            CreateMap<BarberRequestDto, Barber>();
        }
    }
}
