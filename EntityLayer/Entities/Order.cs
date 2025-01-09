namespace EntityLayer.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int TableId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public Table Tables { get; set; }
    }
}
