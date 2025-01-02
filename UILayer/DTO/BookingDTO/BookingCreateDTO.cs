namespace UILayer.DTO.BookingDTO
{
    public class BookingCreateDTO
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int PersonCount { get; set; }
        public string Description { get; set; } = "Rezervasyon Alındı";
        public DateTime Date { get; set; }
    }
}
