using System;

namespace MarketSquare.API.Data.Models
{
    public class Notice : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public User Creator { get; set; }
        public DateTime CreationDateTime { get;set; }
    }
}