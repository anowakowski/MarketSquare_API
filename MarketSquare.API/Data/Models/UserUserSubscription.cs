using System.ComponentModel.DataAnnotations.Schema;

namespace MarketSquare.API.Data.Models
{
    public class UserUserSubscription : Entity
    {
        public User User { get; set; }
        public User SubscribedUser { get; set; }
        public bool IsBlacklisted { get; set; }
    }
}