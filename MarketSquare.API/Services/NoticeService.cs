using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketSquare.API.Data.Models;
using MarketSquare.API.Data.Repositories;
using System.Linq;
using AutoMapper;
using MarketSquare.API.Dtos;

namespace MarketSquare.API.Services
{
    public class NoticeService : INoticeService
    {
        private readonly IRepository<NoticeTag> _noticeTagRepository;
        private readonly IMapper _mapper;        
        public NoticeService(IRepository<NoticeTag> noticeTagRepository, IMapper mapper){
            _noticeTagRepository = noticeTagRepository ?? throw new ArgumentNullException(nameof(noticeTagRepository));;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<NoticeTagForListDto>> GetNoticeTags(){
            var noticeTags = await _noticeTagRepository.FindAsyncWithIncludedEntities(x=> true, 
                include => include.Notice,
                include2 => include2.Tag,
                include3 => include3.Notice.Creator);
            var noticeTagsDto = _mapper.Map<IEnumerable<NoticeTagForListDto>>(noticeTags);
            return noticeTagsDto;
        }
    }
}