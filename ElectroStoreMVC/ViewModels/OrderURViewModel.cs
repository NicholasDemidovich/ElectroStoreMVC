using ElectroStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectroStoreMVC.ViewModels
{
    public class OrderURViewModel
    {
        public List<OrderProductViewModel> OrderProductViewModels { get; set; }
        public List<UserReviewViewModel> UserReviewViewModel { get; set; }
    }
}
