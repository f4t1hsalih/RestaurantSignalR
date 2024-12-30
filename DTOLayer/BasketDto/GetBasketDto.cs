namespace DTOLayer.BasketDto
{
    public class GetBasketDto
    {
        public int BasketId { get; set; }
        public int TableId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
