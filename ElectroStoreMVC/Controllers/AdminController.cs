using ElectroStoreMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace ElectroStoreMVC.Controllers
{
    public class AdminController : Controller
    {
        StoreContext db;
        public AdminController(StoreContext context)
        {
            db = context;
        }
        [Authorize(Roles = "admin")]
        public IActionResult AllProducts()
        {
            return View(db.Products.ToList());
        }

        [Authorize(Roles = "admin")]
        public IActionResult AddProduct()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return View();
        }
    }
}
