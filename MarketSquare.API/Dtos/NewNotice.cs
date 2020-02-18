namespace MarketSquare.API.Dtos
{
    public class NewNotice
    {
        public string Name{ get; set; }
        public string Description { get; set; }
        public TagForListDto[] Tags { get; set; }
    }
}