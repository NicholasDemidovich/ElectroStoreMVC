using System;

namespace ElectroStoreMVC.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public int AmountOfProduct { get; set; }
        public DateTime OrderDate { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
