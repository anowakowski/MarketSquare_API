using AutoMapper;
using MarketSquare.API.Data.Models;
using MarketSquare.API.Dtos;

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
        }
    }
}