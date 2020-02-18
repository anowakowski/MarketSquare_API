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
        INoticesRepository _noticeRepository;
        IRepository<User> _userRepository;
        private readonly IMapper _mapper;        
        public NoticeService(
         INoticesRepository noticeRepository,
         IRepository<User> userRepository,
         IMapper mapper){
            _noticeRepository = noticeRepository ?? throw new ArgumentNullException(nameof(noticeRepository));;
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<NoticeTagForListDto>> GetNoticeTags(int[] tags= null){

            List<Notice> notices;
            if(tags!= null && tags.Length > 0){
                notices = _noticeRepository.GetAllNotices(tags).ToList();
            }else{
                notices = _noticeRepository.GetAllNotices().ToList();
            }
            
            foreach(var notice in notices) 
            {
                var creator =  _userRepository.Find(x=> x.Id == notice.CreatorId).First();
                notice.Creator = creator;
            }

            var noticeTagsDto = _mapper.Map<IEnumerable<NoticeTagForListDto>>(notices);
            return noticeTagsDto;
        }
    }
}