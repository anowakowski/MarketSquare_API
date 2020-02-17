using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketSquare.API.Data;
using MarketSquare.API.Data.Models;
using MarketSquare.API.Data.Repositories;

namespace MarketSquare.API.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly IRepository<UserTagSubscription> _userTagSubscribtionRepo;
        private readonly IRepository<UserUserSubscription> _userUserSubscribtionRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Tag> _tagRepo;
        private readonly IUnitOfWork _unitOfWork;

        public SettingsService(
            IRepository<UserTagSubscription> userTagSubscribtionRepo, 
            IRepository<UserUserSubscription> userUserSubscribtionRepo,
            IRepository<User> userRepo,
            IRepository<Tag> tagRepo,
            IUnitOfWork unitOfWork)
        {
            _userTagSubscribtionRepo = userTagSubscribtionRepo ?? throw new ArgumentNullException(nameof(userTagSubscribtionRepo));
            _userUserSubscribtionRepo = userUserSubscribtionRepo ?? throw new ArgumentNullException(nameof(userUserSubscribtionRepo));
            _userRepo = userRepo ?? throw new ArgumentNullException(nameof(userRepo));
            _tagRepo = tagRepo ?? throw new ArgumentNullException(nameof(tagRepo));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<UserTagSubscription>> GetSubscribedTags(string username) 
        {
            return await _userTagSubscribtionRepo.FindAsyncWithIncludedEntities(
                sub => sub.User.Username == username && sub.IsBlacklisted == false, 
                sub => sub.User, 
                sub => sub.Tag);
        }

        public async Task<IEnumerable<UserTagSubscription>> GetBlacklistedTags(string username) 
        {
            return await _userTagSubscribtionRepo.FindAsyncWithIncludedEntities(
                sub => sub.User.Username == username && sub.IsBlacklisted == true, 
                sub => sub.User, 
                sub => sub.Tag);
        }

        public async Task<IEnumerable<UserUserSubscription>> GetSubscribedUsers(string username) 
        {
            return await _userUserSubscribtionRepo.FindAsyncWithIncludedEntities(
                sub => sub.User.Username == username && sub.IsBlacklisted == false, 
                sub => sub.User, 
                sub => sub.SubscribedUser);
        }

        public async Task<IEnumerable<UserUserSubscription>> GetBlacklistedUsers(string username) 
        {
            return await _userUserSubscribtionRepo.FindAsyncWithIncludedEntities(
                sub => sub.User.Username == username && sub.IsBlacklisted == true, 
                sub => sub.User, 
                sub => sub.SubscribedUser);
        }

        public async Task SubscribeUser(string username, string subscribedUsername)
        {
            var entity = new UserUserSubscription()
            {
                IsBlacklisted = false,
                SubscribedUser = await GetUser(subscribedUsername),
                User = await GetUser(username)                
            };

            await _userUserSubscribtionRepo.AddAsync(entity);

            await _unitOfWork.CompleteAsync();
        }
        public async Task UnsubscribeUser(string username, string subscribedUsername)
        {
            var ent = await _userUserSubscribtionRepo
                .FirstOrDefaultAsync(e => e.User.Username == username && e.SubscribedUser.Username == subscribedUsername && e.IsBlacklisted == false);

             _userUserSubscribtionRepo.Delete(ent);

            await _unitOfWork.CompleteAsync();
        }

        public async Task SubscribeTag(string username, string tag)
        {
            var entity = new UserTagSubscription()
            {
                IsBlacklisted = false,
                Tag = await GetTag(tag),
                User = await GetUser(username)                
            };

            await _userTagSubscribtionRepo.AddAsync(entity);

            await _unitOfWork.CompleteAsync();
        }

        public async Task UnsubscribeTag(string username, string tag)
        {
            var ent = await _userTagSubscribtionRepo
                .FirstOrDefaultAsync(e => e.User.Username == username && e.Tag.Name == tag && e.IsBlacklisted == false);

             _userTagSubscribtionRepo.Delete(ent);

            await _unitOfWork.CompleteAsync();
        }

        public async Task UnblacklistTag(string username, string tag)
        {
            var ent = await _userTagSubscribtionRepo
                .FirstOrDefaultAsync(e => e.User.Username == username && e.Tag.Name == tag && e.IsBlacklisted == true);

             _userTagSubscribtionRepo.Delete(ent);

            await _unitOfWork.CompleteAsync();
        }

        public async Task BlacklistTag(string username, string tag)
        {
            var entity = new UserTagSubscription()
            {
                IsBlacklisted = true,
                Tag = await GetTag(tag),
                User = await GetUser(username)                
            };

            await _userTagSubscribtionRepo.AddAsync(entity);

            await _unitOfWork.CompleteAsync();
        }

        public async Task UnblacklistUser(string username, string subscribedUsername)
        {
            var ent = await _userUserSubscribtionRepo
                .FirstOrDefaultAsync(e => e.User.Username == username && e.SubscribedUser.Username == subscribedUsername && e.IsBlacklisted == true);

             _userUserSubscribtionRepo.Delete(ent);

            await _unitOfWork.CompleteAsync();
        }

        public async Task BlacklistUser(string username, string subscribedUsername)
        {
            var entity = new UserUserSubscription()
            {
                IsBlacklisted = true,
                SubscribedUser = await GetUser(subscribedUsername),
                User = await GetUser(username)                
            };

            await _userUserSubscribtionRepo.AddAsync(entity);

            await _unitOfWork.CompleteAsync();
        }    

        private async Task<User> GetUser(string username)
        {
            return await _userRepo.FirstOrDefaultAsync(u => u.Username == username);
        }

        private async Task<Tag> GetTag(string tag)
        {
            return await _tagRepo.FirstOrDefaultAsync(t => t.Name == tag);
        }
    }
}