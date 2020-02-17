using System.ComponentModel.DataAnnotations.Schema;

namespace MarketSquare.API.Data.Models
{
    public class NoticeTag : Entity
    {
        public Notice Notice { get; set; }
        public Tag Tag { get; set; }
    }
}