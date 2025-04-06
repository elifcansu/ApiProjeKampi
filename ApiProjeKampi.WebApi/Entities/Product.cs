﻿namespace ApiProjeKampi.WebApi.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; } //CategoryId boş geçilebilir anlamında ? eklendi.
        public Category Category { get; set; }
    }
}
