using Agendify.Application.Dtos.Service;
using Agendify.Entities;
using AutoMapper;

namespace Agendify.WebApi.Mapping
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<Service, ServiceResponseDto>().
                ForMember(dest => dest.Name, ori => ori.MapFrom(src => src.Name));
            CreateMap<ServiceRequestDto, Service>();
        }
    }
}
