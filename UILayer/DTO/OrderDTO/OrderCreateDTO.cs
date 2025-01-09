namespace UILayer.DTO.OrderDTO
{
    public class OrderCreateDTO
    {
        public int TableId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
