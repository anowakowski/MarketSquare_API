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
            Map();
        }
        private void Map()
        {
           CreateMap<UserNoticeDto, UserNotice>()
                .ForMember(dest => dest.User, opt => { opt.MapFrom(src => src.User);})
                .ForMember(dest => dest.Notice, opt => { opt.MapFrom(src => src.Notice);})
                .ForMember(dest => dest.IsSent, opt => { opt.MapFrom(src => src.IsSent);})
                .ForMember(dest => dest.IsRead, opt => { opt.MapFrom(src => src.IsRead);})
                .ReverseMap();

            CreateMap<Notice, NoticeTagForListDto>()
                .ForMember(dest => dest.CreationDate, opt => { opt.MapFrom(src => src.CreationDateTime);})
                .ForMember(dest => dest.CreatorName, opt => { opt.MapFrom(src => src.Creator.Username);})
                .ForMember(dest => dest.Name, opt => { opt.MapFrom(src => src.Name);})
                .ForMember(dest => dest.Description, opt => { opt.MapFrom(src => src.Description);})
                .ForMember(dest => dest.Tags, opt => { opt.MapFrom(src => src.NoticeTags);})
                .ReverseMap();

            CreateMap<User, UserForDetailedDto>().ReverseMap();
            CreateMap<NewNotice, Notice>()
                .ForMember(dest => dest.Name, opt => { opt.MapFrom(src => src.Name);})
                .ForMember(dest => dest.Description, opt => { opt.MapFrom(src => src.Description);})
                .ForMember(dest => dest.NoticeTags, opt => { opt.MapFrom(src => src.Tags);})
                .ReverseMap();

            CreateMap<Notice, NoticeTagForListDto>()
                .ForMember(dest => dest.CreatorName,
                    opt => { opt.MapFrom(src => src.Creator.Username); })
                .ForMember(dest => dest.Tags,
                    opt => { opt.MapFrom(src => src.NoticeTags.Select(x => x.Tag)); })
                .ForMember(dest => dest.CreationDate,
                opt => {opt.MapFrom(src => src.CreationDateTime);}).ReverseMap();
            CreateMap<Tag, TagForListDto>().ReverseMap();
        }
    }
}