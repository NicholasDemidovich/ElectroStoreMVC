using ElectroStoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public IActionResult AllProducts()
        {
            return View(db.Products.ToList());
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return View();
        }
    }
}
