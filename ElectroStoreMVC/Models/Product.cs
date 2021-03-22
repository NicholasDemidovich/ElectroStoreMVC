using System;


namespace ElectroStoreMVC.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int ProductCount { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public bool IsDeleted { get; set; }
    }
}
