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
    }
}