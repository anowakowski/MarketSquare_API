using System.Collections.Generic;

namespace MarketSquare.API.Dtos
{
    public class NoticeTagForListDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatorName { get; set; }
        public int CreationDateTime { get; set; }
        public IEnumerable<TagForListDto> Tags { get; set; }
    }
}