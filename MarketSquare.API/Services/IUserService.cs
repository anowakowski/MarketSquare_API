using System.Collections.Generic;
using System.Threading.Tasks;
using MarketSquare.API.Data.Models;
using MarketSquare.API.Dtos;

namespace MarketSquare.API.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserForDetailedDto>> GetUsers() ;
    }
}