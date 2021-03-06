using System.Collections.Generic;
using System.Threading.Tasks;
using MarketSquare.API.Dtos;

namespace MarketSquare.API.Services
{
    public interface ITagService
    {
        Task<IEnumerable<TagForListDto>> GetAllTags();
        Task<IEnumerable<TagForListDto>> GetTagsByName(string name);
        Task AddTag(TagForListDto t);
    }
}