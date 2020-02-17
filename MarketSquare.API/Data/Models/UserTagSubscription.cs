using System.ComponentModel.DataAnnotations.Schema;

namespace MarketSquare.API.Data.Models
{
    [Table("UserTagSubscription")]
    public class UserTagSubscription : Entity
    {
        public User User { get; set; }
        public Tag Tag { get; set; }

        public bool IsBlacklisted { get; set; }
    }
}