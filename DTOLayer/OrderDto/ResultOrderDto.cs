namespace DTOLayer.OrderDto
{
    public class ResultOrderDto
    {
        public int OrderId { get; set; }
        public int TableId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
