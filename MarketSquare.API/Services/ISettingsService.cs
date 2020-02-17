using System.Collections.Generic;
using System.Threading.Tasks;
using MarketSquare.API.Data.Models;

namespace MarketSquare.API.Services
{
    public interface ISettingsService
    {
        Task<IEnumerable<UserTagSubscription>> GetSubscribedTags(string username);

        Task<IEnumerable<UserTagSubscription>> GetBlacklistedTags(string username);

        Task<IEnumerable<UserUserSubscription>> GetSubscribedUsers(string username);

        Task<IEnumerable<UserUserSubscription>> GetBlacklistedUsers(string username);
        Task SubscribeUser(string username, string subscribedUsername);
        Task UnsubscribeUser(string username, string subscribedUsername);
        Task SubscribeTag(string username, string tag);
        Task UnsubscribeTag(string username, string tag);
        Task UnblacklistTag(string username, string tag);
        Task BlacklistTag(string username, string tag);
        Task UnblacklistUser(string username, string subscribedUsername);
        Task BlacklistUser(string username, string subscribedUsername);
    }
}