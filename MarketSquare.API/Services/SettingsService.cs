using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketSquare.API.Data.Models;
using MarketSquare.API.Data.Repositories;

namespace MarketSquare.API.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly IRepository<UserTagSubscription> _userTagSubscribtionRepo;
        private readonly IRepository<UserUserSubscription> _userUserSubscribtionRepo;
        public SettingsService(IRepository<UserTagSubscription> userTagSubscribtionRepo, IRepository<UserUserSubscription> userUserSubscribtionRepo)
        {
            _userTagSubscribtionRepo = userTagSubscribtionRepo ?? throw new ArgumentNullException(nameof(userTagSubscribtionRepo));
            _userUserSubscribtionRepo = userUserSubscribtionRepo ?? throw new ArgumentNullException(nameof(userUserSubscribtionRepo));
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

    }
}