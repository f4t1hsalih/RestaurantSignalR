﻿namespace DTOLayer.BasketDto
{
    public class InsertBasketDto
    {
        public int TableId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
