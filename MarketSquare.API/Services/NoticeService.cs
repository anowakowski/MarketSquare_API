using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketSquare.API.Data.Models;
using MarketSquare.API.Data.Repositories;
using System.Linq;
using AutoMapper;
using MarketSquare.API.Dtos;
using MarketSquare.API.Data;

namespace MarketSquare.API.Services
{
    public class NoticeService : INoticeService
    {
        INoticesRepository _noticeRepository;
        IRepository<User> _userRepository;
        IRepository<Tag> _tagRepository;        
        IRepository<NoticeTag> _noticeTagRepository;
        private readonly IMapper _mapper;   
        private readonly IUnitOfWork _unitOfWork;
        public NoticeService(
         INoticesRepository noticeRepository,
         IRepository<User> userRepository,
         IRepository<Tag> tagRepository,
         IRepository<NoticeTag> noticeTagRepository,
         IMapper mapper,
         IUnitOfWork unitOfWork){
            _noticeRepository = noticeRepository ?? throw new ArgumentNullException(nameof(noticeRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
            _noticeTagRepository = noticeTagRepository ?? throw new ArgumentNullException(nameof(noticeTagRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<NoticeTagForListDto> GetNoticeTags(){

            var allNotices = _noticeRepository.GetAllNotices().ToList();

            foreach(var notice in allNotices) 
            {
                var creator =  _userRepository.Find(x=> x.Id == notice.CreatorId).First();
                notice.Creator = creator;
            }

            var noticeTagsDto = _mapper.Map<IEnumerable<NoticeTagForListDto>>(allNotices);
            return noticeTagsDto;
        }

        public async Task AddNotice(NewNotice notice)
        {
            var tags = notice.Tags;
            notice.Tags = null;
            
            var dbNotice = _mapper.Map<Notice>(notice);
            dbNotice.CreationDateTime = DateTime.Now;
            dbNotice.CreatorId = 1;
            await _noticeRepository.AddAsync(dbNotice);

            foreach(var tag in tags)
            {
                var dbTag = await _tagRepository.FirstOrDefaultAsync(t => t.Name == tag.Name);

                var binding = new NoticeTag()
                {
                    Notice = dbNotice,
                    Tag = dbTag
                };

                await _noticeTagRepository.AddAsync(binding);
            }

            await _unitOfWork.CompleteAsync();
        }
    }
}