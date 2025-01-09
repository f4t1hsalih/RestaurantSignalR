namespace UILayer.DTO.OrderDTO
{
    public class OrderResultDTO
    {
        public int OrderId { get; set; }
        public int TableId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
