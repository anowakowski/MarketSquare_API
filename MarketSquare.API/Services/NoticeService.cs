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
        private readonly IRepository<Notice> _noticeTagRepository;
        private readonly IRepository<Notice> _noticeRepository;
        private readonly IMapper _mapper;        
        public NoticeService(IRepository<Notice> noticeTagRepository,
         IRepository<Notice> noticeRepository,
         IMapper mapper){
            _noticeTagRepository = noticeTagRepository ?? throw new ArgumentNullException(nameof(noticeTagRepository));;
            _noticeRepository = noticeRepository ?? throw new ArgumentNullException(nameof(noticeRepository));;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<NoticeTagForListDto>> GetNoticeTags(){
            /*var noticeTags = await _noticeTagRepository.FindAsyncWithIncludedEntities(x=> true, 
                includeTagName => includeTagName.NoticeTags,
                includeUserName => includeUserName.Creator.Username);*/
            //var noticeTagsDto = _mapper.Map<IEnumerable<NoticeTagForListDto>>(noticeTags);
            var noticeTags = await _noticeTagRepository.FindAsyncWithIncludedEntities(x=> true, 
                includeTagName => includeTagName);
            var notice = await _noticeRepository.FindAsyncWithIncludedEntities(x=> true, 
                include => include.NoticeTags);
            var tags = notice.Select(x=> x.NoticeTags.Select(x => x.Tag)).ToList();
            var noticeTagsDto = new List<NoticeTagForListDto>();
            return noticeTagsDto;
        }
    }
}