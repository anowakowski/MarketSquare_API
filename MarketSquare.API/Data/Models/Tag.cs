using System.Collections.Generic;
namespace MarketSquare.API.Data.Models
{
    public class Tag : Entity
    {
        public string Name { get; set; }
        public ICollection<NoticeTag> NoticeTags { get; set; }
    }
} 