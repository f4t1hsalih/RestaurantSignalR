namespace UILayer.DTO.ProductDTO
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; } = true;
        public int CategoryId { get; set; }
    }
}
