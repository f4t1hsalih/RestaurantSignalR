﻿namespace EntityLayer.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string TableNumber { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
