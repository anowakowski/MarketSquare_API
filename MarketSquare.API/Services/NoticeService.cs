using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketSquare.API.Data.Models;
using MarketSquare.API.Data.Repositories;

namespace MarketSquare.API.Services
{
    public class NoticeService : INoticeService
    {
        private readonly IRepository<Notice> _noticeRepository;
        public NoticeService(IRepository<Notice> noticeRepository){
            _noticeRepository = noticeRepository ?? throw new ArgumentNullException(nameof(noticeRepository));;
        }

        public async Task<IEnumerable<Notice>> GetNotices(){
            return await _noticeRepository.GetAllAsync();
        }
    }
}