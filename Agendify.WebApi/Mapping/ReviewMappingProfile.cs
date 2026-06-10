using Agendify.Application.Dtos.Review;
using Agendify.Entities;
using AutoMapper;

namespace Agendify.WebApi.Mapping
{
    public class ReviewMappingProfile:Profile
    {
      public ReviewMappingProfile()
        {
            CreateMap<Review, ReviewResponseDto>()
            .ForMember(dest => dest.Comment,
                ori => ori.MapFrom(src => src.Comment))

            .ForMember(dest => dest.ReviewDate,
                ori => ori.MapFrom(src => src.ReviewDate));

            CreateMap<ReviewRequestDto, Review>();
        }
    }
}
