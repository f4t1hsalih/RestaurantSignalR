namespace UILayer.DTO.BasketDTO
{
    public class BasketResultDTO
    {
        public int BasketId { get; set; }
        public int TableId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
