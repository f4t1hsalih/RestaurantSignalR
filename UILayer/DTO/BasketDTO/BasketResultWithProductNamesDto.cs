﻿namespace UILayer.DTO.BasketDTO
{
    public class BasketResultWithProductNamesDto
    {
        public int BasketId { get; set; }
        public string TableName { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
