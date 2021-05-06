using ElectroStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectroStoreMVC.ViewModels
{
    public class ProductReviewViewModel
    {
        public Product Product { get; set; }
        public List<ProductUNViewModel> ProductReviews { get; set; }
    }
}
