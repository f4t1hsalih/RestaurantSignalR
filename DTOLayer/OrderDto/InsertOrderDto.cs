namespace DTOLayer.OrderDto
{
    public class InsertOrderDto
    {
        public int TableId { get; set; }
        public string Description { get; set; } = "Müşteri Masada";
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; } = 0;
    }
}
