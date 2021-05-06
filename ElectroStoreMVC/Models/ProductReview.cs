using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectroStoreMVC.Models
{
    public class ProductReview
    {
        public int ProductReviewId { get; set; }
        public string ProductReviewContext { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
