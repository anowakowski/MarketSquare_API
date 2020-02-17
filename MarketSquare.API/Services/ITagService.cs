using System.Collections.Generic;
using System.Threading.Tasks;
using MarketSquare.API.Data.Models;

namespace MarketSquare.API.Services
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAllTags();
    }
}