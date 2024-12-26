namespace EntityLayer.Entities
{
    public class Basket
    {
        public int BasketId { get; set; }
        public int TableId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        public Product Products { get; set; }
        public Table Tables { get; set; }
    }
}
