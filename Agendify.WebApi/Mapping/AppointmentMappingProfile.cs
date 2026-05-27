using Agendify.Application.Dtos.Appointment;
using Agendify.Entities;
using AutoMapper;

namespace Agendify.WebApi.Mapping
{
    public class AppointmentMappingProfile : Profile
    {
        public AppointmentMappingProfile()
        {
            CreateMap<AppointmentRequestDto, Appointment>();

            CreateMap<Appointment, AppointmentResponseDto>()
                .ForMember(dest => dest.ClientName,
                    opt => opt.MapFrom(src => src.Client!.FullName))

                .ForMember(dest => dest.BarberName,
                    opt => opt.MapFrom(src => src.Barber!.FullName));
        }
    }
}
