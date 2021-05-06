using ElectroStoreMVC.Models;
using Microsoft.AspNetCore.Authorization;
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

        public IActionResult ProductDeletePerm(int? id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();

            return Redirect("~/Admin/AllProducts/?id=1");
            //return RedirectToAction("AllProducts", "Admin");
        }

        public IActionResult ProductDeleteTemp(int? id)
        {
            var product = db.Products.Find(id);
            product.IsDeleted = true;
            db.SaveChanges();

            return Redirect("~/Admin/AllProducts/?id=1");
            //return RedirectToAction("AllProducts", "Admin");
        }


        public IActionResult EditProductPage(int? id)
        {
            return View(db.Products.Find(id));
        }

        [HttpPost]
        public IActionResult EditProductPage(Product product, int? id)
        {
            var pr = db.Products
                .Where(p => p.ProductId == id)
                .FirstOrDefault();

            pr.ProductName = product.ProductName;
            pr.ProductPrice = product.ProductPrice;
            pr.ProductType = product.ProductType;
            pr.ProductDescription = product.ProductDescription;
            pr.ProductCount = product.ProductCount;
            pr.ProductImage = product.ProductImage;
            pr.ProductId = (int)id;

            db.SaveChanges();

            return View(db.Products.Find(id));
        }


        [Authorize(Roles = "admin")]
        public IActionResult AllProducts(int? id)
        {
            if (id == null)
            {
                id = 1;
            }
            double countProductsOnOnePage = 12f;

            int count = (int)Math.Ceiling((decimal)(db.Products.ToList().Count / countProductsOnOnePage));
            ViewBag.PagesCount = count;
            var listProduct = new List<Product>();
            var allProduct = db.Products.ToList();

            int length = 0;

            if ((id * countProductsOnOnePage) > allProduct.Count)
            {
                length = allProduct.Count;
            }
            else
            {
                length = (int)(id * countProductsOnOnePage);
            }
            for (int i = (int)(id * countProductsOnOnePage - countProductsOnOnePage); i < length; i++)
            {
                if (allProduct[i].IsDeleted != true)
                {
                    listProduct.Add(allProduct[i]);
                }
            }
            return View(listProduct);
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
