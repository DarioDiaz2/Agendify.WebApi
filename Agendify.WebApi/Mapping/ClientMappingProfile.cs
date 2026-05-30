using Agendify.Application.Dtos.Client;
using Agendify.Entities;
using AutoMapper;

namespace Agendify.WebApi.Mapping
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<Client, ClientResponseDto>()
            .ForMember(dest => dest.FullName,
                ori => ori.MapFrom(src => src.FullName))

            .ForMember(dest => dest.Phone,
                ori => ori.MapFrom(src => src.Phone))

            .ForMember(dest => dest.Email,
                ori => ori.MapFrom(src => src.Email))

            .ForMember(dest => dest.CreatedDate,
                ori => ori.MapFrom(src => src.CreatedDate));

            CreateMap<ClientRequestDto, Client>();
        }
    }
}
