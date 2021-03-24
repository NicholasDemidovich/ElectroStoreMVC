using ElectroStoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ElectroStoreMVC.Controllers
{
    public class AllProductsController : Controller
    {
        StoreContext db;
        public AllProductsController(StoreContext context)
        {
            db = context;
        }
        public IActionResult AllProducts()
        {
            return View(db.Products.ToList());
        }
    }
}
