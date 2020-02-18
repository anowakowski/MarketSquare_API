using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MarketSquare.API.Data;
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
        private readonly IUnitOfWork _unitOfWork;

        public TagService(
            IRepository<Tag> tagsRepository, 
            IMapper mapper, 
            IUnitOfWork unitOfWork)
        {
            _tagsRepository = tagsRepository ?? throw new ArgumentNullException(nameof(tagsRepository));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task AddTag(TagForListDto tag)
        {
            var dbTag = _mapper.Map<Tag>(tag);
            var existingTag = await _tagsRepository.FirstOrDefaultAsync(t =>t.Name == tag.Name);
            if(existingTag == null)
            {
                await _tagsRepository.AddAsync(dbTag);
            }

            await _unitOfWork.CompleteAsync();
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
