﻿namespace Shop.BLL.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int ProductId { get; set; }

        public decimal TotalPrice { get; set; }

        public int Quantity { get; set; }
    }
}
