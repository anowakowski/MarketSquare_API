using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MarketSquare.API.Data.Models;
using MarketSquare.API.Data.Repositories;
using MarketSquare.API.Dtos;
using Microsoft.EntityFrameworkCore;

namespace MarketSquare.API.Services
{
    public class TagService : ITagService
    {
        private readonly IRepository<Tag> _tagsRepository;
        private readonly IMapper _mapper;

        public TagService(IRepository<Tag> tagsRepository, IMapper mapper)
        {
            _tagsRepository = tagsRepository ?? throw new ArgumentNullException(nameof(tagsRepository));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<TagForListDto>> GetAllTags()
        {
            var tags = await _tagsRepository.GetAllAsync();

            var tagsDto = _mapper.Map<IEnumerable<TagForListDto>>(tags);

            return tagsDto;
        }

        public async Task<IEnumerable<TagForListDto>> GetTagsByName(string name)
        {
            var tags = await _tagsRepository.FindAsync(tag => EF.Functions.Like(tag.Name, $"%{name}%"));

            var tagsDto = _mapper.Map<IEnumerable<TagForListDto>>(tags);

            return tagsDto;
        }
    }
}
