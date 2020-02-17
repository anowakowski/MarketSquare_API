using AutoMapper;
using MarketSquare.API.Data.Models;
using MarketSquare.API.Dtos;
using System.Linq;

namespace MarketSquare.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            FromDomainToDto();
        }
        private void FromDomainToDto()
        {
            CreateMap<User, UserForDetailedDto>();
            CreateMap<NoticeTag, NoticeTagForListDto>()
                .ForMember(dest => dest.CreatorName,
                    opt => { opt.MapFrom(src => src.Notice.Creator.Username); });
            CreateMap<Tag, TagForListDto>();
        }
    }
}