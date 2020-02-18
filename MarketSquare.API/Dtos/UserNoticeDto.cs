using System;

namespace MarketSquare.API.Dtos
{
    public class UserNoticeDto    
    {
        public NoticeTagForListDto Notice { get; set; }
        public UserForDetailedDto User {get; set;}
        public bool IsSent { get; set; }
        public bool IsRead { get; set; }
    }
}