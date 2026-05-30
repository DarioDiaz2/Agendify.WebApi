using Agendify.Application.Dtos.Payment;
using Agendify.Entities;
using AutoMapper;

namespace Agendify.WebApi.Mapping
{
    public class PaymentMappingProfile:Profile
    {
        public PaymentMappingProfile()
        {
            CreateMap<Payment, PaymentResponseDto>()
            .ForMember(dest => dest.AppointmentId,
                ori => ori.MapFrom(src => src.AppointmentId))

            .ForMember(dest => dest.Amount,
                ori => ori.MapFrom(src => src.Amount))

            .ForMember(dest => dest.PaymentDate,
                ori => ori.MapFrom(src => src.PaymentDate));

            CreateMap<PaymentRequestDto, Payment>();
        }
    }
}
