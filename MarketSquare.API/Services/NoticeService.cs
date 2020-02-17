using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketSquare.API.Data.Models;
using MarketSquare.API.Data.Repositories;
using System.Linq;

namespace MarketSquare.API.Services
{
    public class NoticeService : INoticeService
    {
        private readonly IRepository<NoticeTag> _noticeTagRepository;
        public NoticeService(IRepository<NoticeTag> noticeTagRepository){
            _noticeTagRepository = noticeTagRepository ?? throw new ArgumentNullException(nameof(noticeTagRepository));;
        }

        public async Task<IEnumerable<NoticeTag>> GetNotices(){
            var result = await _noticeTagRepository.FindAsyncWithIncludedEntities(x=> true, 
                include => include.Notice,
                include2 => include2.Tag);
            return result;
        }
    }
}