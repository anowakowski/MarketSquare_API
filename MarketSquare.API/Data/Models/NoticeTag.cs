using System.ComponentModel.DataAnnotations.Schema;

namespace MarketSquare.API.Data.Models
{
    public class NoticeTag : Entity
    {
        public int NoticeId { get; set; }
        public virtual Notice Notice { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}