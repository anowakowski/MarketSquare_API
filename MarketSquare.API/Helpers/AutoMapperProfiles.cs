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
            CreateMap<Notice, NoticeTagForListDto>()
                .ForMember(dest => dest.CreatorName,
                    opt => { opt.MapFrom(src => src.Creator.Username); })
                .ForMember(dest => dest.Tags,
                    opt => { opt.MapFrom(src => src.NoticeTags.Select(x => x.Tag)); })
                .ForMember(dest => dest.CreationDate,
                opt => {opt.MapFrom(src => src.CreationDateTime);});
            CreateMap<Tag, TagForListDto>();
        }
    }
}