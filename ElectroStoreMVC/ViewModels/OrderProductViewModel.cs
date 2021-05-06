using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectroStoreMVC.Models
{
    public class OrderProductViewModel
    {
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
