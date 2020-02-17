using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketSquare.API.Data.Models;
using MarketSquare.API.Data.Repositories;

namespace MarketSquare.API.Services
{
    public class TagService : ITagService
    {
        private readonly IRepository<Tag> _tagsRepository;

        public TagService(IRepository<Tag> tagsRepository)
        {
            _tagsRepository = tagsRepository ?? throw new ArgumentNullException(nameof(tagsRepository));
        }

        public async Task<IEnumerable<Tag>> GetAllTags()
        {
            return await _tagsRepository.GetAllAsync();
        }
    }
}
