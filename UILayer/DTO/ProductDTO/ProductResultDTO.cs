namespace UILayer.DTO.ProductDTO
{
    public class ProductResultDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; } = true;
        public string CategoryName { get; set; }
    }
}
