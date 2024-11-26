namespace DTOLayer.ProductDto
{
    public class GetProductWithCategoryDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public string CategoryName { get; set; }
    }
}
