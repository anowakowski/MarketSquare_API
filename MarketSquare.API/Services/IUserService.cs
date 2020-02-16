using System.Collections.Generic;
using System.Threading.Tasks;
using MarketSquare.API.Data.Models;

namespace MarketSquare.API.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers() ;
    }
}