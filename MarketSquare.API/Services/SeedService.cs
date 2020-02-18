using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketSquare.API.Data;
using MarketSquare.API.Data.Models;
using MarketSquare.API.Data.Repositories;

namespace MarketSquare.API.Services
{
    public class SeedService : ISeedService
    {
        private readonly IRepository<UserTagSubscription> _userTagSubscribtionRepo;
        private readonly IRepository<UserUserSubscription> _userUserSubscribtionRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Tag> _tagRepo;
        private readonly IRepository<Notice> _noticeRepo;
        private readonly IRepository<UserNotice> _userNoticeRepo;
         private readonly IRepository<NoticeTag> _noticeTagRepo;

        private readonly IUnitOfWork _unitOfWork;

        public SeedService(
            IRepository<UserTagSubscription> userTagSubscribtionRepo, 
            IRepository<UserUserSubscription> userUserSubscribtionRepo,
            IRepository<User> userRepo,
            IRepository<Tag> tagRepo,
            IRepository<Notice> noticeRepo,
            IRepository<UserNotice> userNoticeRepo,
            IRepository<NoticeTag> noticeTagRepo,
            IUnitOfWork unitOfWork)
        {
            _userTagSubscribtionRepo = userTagSubscribtionRepo ?? throw new ArgumentNullException(nameof(userTagSubscribtionRepo));
            _userUserSubscribtionRepo = userUserSubscribtionRepo ?? throw new ArgumentNullException(nameof(userUserSubscribtionRepo));
            _userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
            _tagRepo = tagRepo ?? throw new ArgumentNullException(nameof(tagRepo));
            _noticeRepo = noticeRepo ?? throw new ArgumentNullException(nameof(noticeRepo));
            _userNoticeRepo = userNoticeRepo ?? throw new ArgumentNullException(nameof(userNoticeRepo));
            _noticeTagRepo = noticeTagRepo ?? throw new ArgumentNullException(nameof(noticeTagRepo));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task Seed()
        {
            var user1 = new User()
            {
                Username = "kamil",
                Email = "Kamil@obj.pl"
            };

            var user2 = new User()
            {
                Username = "Adrian",
                Email = "Adrian@obj.pl"
            };

            var user3 = new User()
            {
                Username = "Wojtek",
                Email = "Wojtek@obj.pl"
            };

            var user4 = new User()
            {
                Username = "Lukasz",
                Email = "Lukasz@obj.pl"
            };

            await _userRepo.AddAsync(user1);
            await _userRepo.AddAsync(user2);
            await _userRepo.AddAsync(user3);
            await _userRepo.AddAsync(user4);

            var tag1 = new Tag()
            {
                Name = "Buy"
            };

            var tag2 = new Tag()
            {
                Name = "Sell"
            };

            var tag3 = new Tag()
            {
                Name = "Parking"
            };

            var tag4 = new Tag()
            {
                Name = "Party"
            };

            var tag5 = new Tag()
            {
                Name = "Food"
            };

            await _tagRepo.AddAsync(tag1);
            await _tagRepo.AddAsync(tag2);
            await _tagRepo.AddAsync(tag3);
            await _tagRepo.AddAsync(tag4);
            await _tagRepo.AddAsync(tag5);            

            var userSubscr1 = new UserUserSubscription()
            {
                IsBlacklisted = false,
                SubscribedUser = user2,
                User = user1              
            };

            var userSubscr2 = new UserUserSubscription()
            {
                IsBlacklisted = false,
                SubscribedUser = user2,
                User = user1                
            };

            var userSubscr3 = new UserUserSubscription()
            {
                IsBlacklisted = false,
                SubscribedUser = user3,
                User = user1                
            };

            await _userUserSubscribtionRepo.AddAsync(userSubscr1);
            await _userUserSubscribtionRepo.AddAsync(userSubscr2);
            await _userUserSubscribtionRepo.AddAsync(userSubscr3);

             var tagSubscr1 = new UserTagSubscription()
            {
                IsBlacklisted = false,
                Tag = tag1,
                User = user1             
            };

            var tagSubscr2 = new UserTagSubscription()
            {
                IsBlacklisted = false,
                Tag = tag2,
                User = user1              
            };

            var tagSubscr3 = new UserTagSubscription()
            {
                IsBlacklisted = false,
                Tag = tag3,
                User = user1                
            };

            await _userTagSubscribtionRepo.AddAsync(tagSubscr1);
            await _userTagSubscribtionRepo.AddAsync(tagSubscr2);
            await _userTagSubscribtionRepo.AddAsync(tagSubscr3);

            var notice1 = new Notice()
            {
                Creator = user1,
                CreationDateTime = DateTime.Now,
                Name = "Lubie placki",
                Description = "Lubie placki, chetnie kupie"                           
            };

            var notice2 = new Notice()
            {
                Creator = user1,
                CreationDateTime = DateTime.Now,
                Name = "Przeparkuj DW 666",
                Description = "Krzywo zaparkowales, prosze przeparkuj"                           
            };

            await _noticeRepo.AddAsync(notice1);
            await _noticeRepo.AddAsync(notice2);

            var noticeTag1 = new NoticeTag()
            {
                Notice = notice1,
                Tag = tag5
            };

            var noticeTag2 = new NoticeTag()
            {
                Notice = notice1,
                Tag = tag1
            };

            var noticeTag3 = new NoticeTag()
            {
                Notice = notice2,
                Tag = tag3
            };

            await _noticeTagRepo.AddAsync(noticeTag1);
            await _noticeTagRepo.AddAsync(noticeTag2);
            await _noticeTagRepo.AddAsync(noticeTag3);

            var userNotice1 = new UserNotice()
            {
                User = user1,
                Notice = notice1,
                IsRead = false,
                IsSent = false
            };

            var userNotice2 = new UserNotice()
            {
                User = user1,
                Notice = notice2,
                IsRead = false,
                IsSent = false
            };

            await _userNoticeRepo.AddAsync(userNotice1);
            await _userNoticeRepo.AddAsync(userNotice2);

            await _unitOfWork.CompleteAsync();
        }
    }
}