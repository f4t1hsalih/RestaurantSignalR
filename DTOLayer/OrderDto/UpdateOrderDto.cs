namespace DTOLayer.OrderDto
{
    public class UpdateOrderDto
    {
        public int OrderId { get; set; }
        public int TableId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
