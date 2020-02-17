namespace MarketSquare.API.Data.Models
{
    public class UserNotice : Entity
    {
        public Notice Notice { get; set; }
        public User User { get; set; }
        public bool IsRead {get;set;}
        public bool IsSent {get;set;}
    }
}