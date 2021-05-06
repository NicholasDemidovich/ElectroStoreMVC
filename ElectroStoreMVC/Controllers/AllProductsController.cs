using ElectroStoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using ElectroStoreMVC.ViewModels;

namespace ElectroStoreMVC.Controllers
{
    public class AllProductsController : Controller
    {
        StoreContext db;
        public AllProductsController(StoreContext context)
        {
            db = context;
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ProductPage(int? id)
        {
            var prUNList = new List<ProductUNViewModel>();

            var productReviews = new List<ProductReview>();
            var userNames = new List<string>();
            var prRev = new ProductReviewViewModel();

            prRev.Product = db.Products.Find(id);
            productReviews = db.ProductReviews.Where(pr => pr.ProductId == (int)id).ToList();

            foreach(var product in productReviews)
            {
                var prUN = new ProductUNViewModel();
                string userName = db.Users.Find(product.UserId).UserName;
                prUN.UserName = userName;
                prUN.ProductReview = product;

                prUNList.Add(prUN);
            }

            prRev.ProductReviews = prUNList;

            return View(prRev);
        }

        [Authorize]
        public IActionResult DeleteOneProductCookie(int? id)
        {
            string name = User.Identity.Name;

            if (id != null)
            {
                Response.Cookies.Delete(name + id);
            }

            return RedirectToAction("AddToCart", "AllProducts");
        }

        [Authorize]
        public IActionResult ClearCookies()
        {
            string name = User.Identity.Name;
            for (int i = 1; i <= db.Products.Count(); i++)
            {
                if (Request.Cookies[name + i] != null)
                {
                    if (JsonSerializer.Deserialize<ProductViewModel>(Request.Cookies[name + i]) != null)
                    {
                        Response.Cookies.Delete(name + i);
                    }
                }
            }
            return RedirectToAction("AddToCart", "AllProducts");
        }

        [Authorize]
        public IActionResult Cart(int? id)
        {
            ProductViewModel productView = new ProductViewModel();

            string name = User.Identity.Name;

            if (id != null)
            {
                if (Request.Cookies[name + id] != null)
                {
                    productView = JsonSerializer.Deserialize<ProductViewModel>(Request.Cookies[name + id]);
                    productView.Count += 1;

                    Response.Cookies.Append(name + id, JsonSerializer.Serialize(productView));
                }
                else
                {
                    Product product = db.Products.Find((Convert.ToInt32(id)));
                    productView.Count = 1;
                    productView.Product = product;

                    CookieOptions cookieOptions = new CookieOptions();
                    cookieOptions.Expires = DateTime.Now.AddDays(3);

                    Response.Cookies.Append(name + id, JsonSerializer.Serialize(productView));
                }
            }
            return RedirectToAction("AddToCart", "AllProducts");
        }

        [Authorize]
        public IActionResult AddToCart()
        {
            string name = User.Identity.Name;

            List<ProductViewModel> productViewList = new List<ProductViewModel>();
            for (int i = 1; i <= db.Products.Count(); i++)
            {
                if (Request.Cookies[name + i] != null)
                {
                    if (JsonSerializer.Deserialize<ProductViewModel>(Request.Cookies[name + i]) != null)
                    {
                        productViewList.Add(JsonSerializer.Deserialize<ProductViewModel>(Request.Cookies[name + i]));
                    }
                }
            }
            return View(productViewList);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CheckOutPage(string paymentMethod)
        {
            string name = User.Identity.Name;

            List<Order> orderList = new List<Order>();
            List<ProductViewModel> productViewList = new List<ProductViewModel>();
            for (int i = 1; i <= db.Products.Count(); i++)
            {
                if (Request.Cookies[name + i] != null)
                {
                    if (JsonSerializer.Deserialize<ProductViewModel>(Request.Cookies[name + i]) != null)
                    {
                        productViewList.Add(JsonSerializer.Deserialize<ProductViewModel>(Request.Cookies[name + i]));
                    }
                }
            }

            foreach (var prView in productViewList)
            {
                Product product = new Product();
                Order order = new Order();
                User user = new User();

                var us = db.Users.Where(u => u.UserName == name);
                user = us.First();

                order.PaymentMethod = paymentMethod;
                order.AmountOfProduct = prView.Count;
                order.OrderDate = DateTime.Now;

                product = db.Products.Find(prView.Product.ProductId);
                product.ProductCount = product.ProductCount - prView.Count;

                if (product.ProductCount < 0)
                {
                    product.ProductCount = 0;
                }

                db.Products.Update(product);
                db.SaveChanges();

                order.User = user;
                order.Product = product;

                db.Orders.Add(order);
                db.SaveChanges();
            }

            for (int i = 1; i <= db.Products.Count(); i++)
            {
                if (Request.Cookies[name + i] != null)
                {
                    if (JsonSerializer.Deserialize<ProductViewModel>(Request.Cookies[name + i]) != null)
                    {
                        Response.Cookies.Delete(name + i);
                    }
                }
            }

            return RedirectToAction("SuccessOrder", "AllProducts");
        }

        [Authorize]
        public IActionResult SuccessOrder()
        {
            return View();
        }

        [Authorize]
        public IActionResult CheckOutPage(int? id)
        {
            string name = User.Identity.Name;

            List<ProductViewModel> productViewList = new List<ProductViewModel>();

            if (id != null)
            {
                Product endProduct = db.Products.Find(id);
                var prView = new ProductViewModel();
                prView.Count = 1;
                prView.Product = endProduct;
                productViewList.Add(prView);
                Response.Cookies.Append(name + id, JsonSerializer.Serialize(prView));
            }

            for (int i = 1; i <= db.Products.Count(); i++)
            {
                if (Request.Cookies[name + i] != null)
                {
                    if (JsonSerializer.Deserialize<ProductViewModel>(Request.Cookies[name + i]) != null)
                    {
                        productViewList.Add(JsonSerializer.Deserialize<ProductViewModel>(Request.Cookies[name + i]));
                    }
                }
            }

            double sumAmount = 0;

            foreach (var product in productViewList)
            {
                sumAmount += product.Product.ProductPrice * product.Count;
            }

            ViewBag.SumAmount = sumAmount;

            return View(productViewList);
        }

        [HttpPost]
        public IActionResult AllProducts(string data)
        {
            int id = 1;
            var allProducts = new List<Product>();
            var resultListProduct = new List<Product>();

            foreach (var prod in db.Products.ToList())
            {
                if (prod.ProductName.Equals(data))
                {
                    allProducts.Add(prod);
                }
                if (prod.ProductType.Equals(data))
                {
                    allProducts.Add(prod);
                }
                if (prod.ProductDescription.Equals(data))
                {
                    allProducts.Add(prod);
                }
            }

            float countProductsOnOnePage = 12f;

            int count = (int)Math.Ceiling((decimal)(allProducts.Count / countProductsOnOnePage));
            ViewBag.PagesCount = count;

            int length = 0;

            if ((id * countProductsOnOnePage) > allProducts.Count)
            {
                length = allProducts.Count;
            }
            else
            {
                length = (int)(id * countProductsOnOnePage);
            }
            for (int i = (int)(id * countProductsOnOnePage - countProductsOnOnePage); i < length; i++)
            {
                if (allProducts[i].IsDeleted != true)
                {
                    resultListProduct.Add(allProducts[i]);
                }
            }
            return View(resultListProduct);
        }

        public IActionResult AllProducts(int? id)
        {
            if (id == null)
            {
                id = 1;
            }
            float countProductsOnOnePage = 12f;

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

        [Authorize]
        public IActionResult MakeUserReview()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakeUserReview(string UserReviewContext)
        {
            var userReview = new UserReview();

            var user = db.Users
               .Where(u => u.UserName == User.Identity.Name)
               .FirstOrDefault();

            userReview.UserReviewContext = UserReviewContext;
            userReview.User = user;

            db.UserReviews.Add(userReview);
            db.SaveChanges();

            return View();
        }

        [Authorize]
        public IActionResult MakeProductReview(int? id)
        {
            return View(id);
        }

        [HttpPost]
        public IActionResult MakeProductReview(string ProductReviewContext, int? id)
        {
            var review = new ProductReview();
            
            var product = db.Products
                .Where(p => p.ProductId == id)
                .FirstOrDefault();

            var user = db.Users
                .Where(u => u.UserName == User.Identity.Name)
                .FirstOrDefault();


            review.ProductReviewContext = ProductReviewContext;
            review.User = user;
            review.Product = product;

            db.ProductReviews.Add(review);
            db.SaveChanges();

            return View(id);
        }

        public IActionResult SomeProducts(string[] items)
        {
            int productCategory = Convert.ToInt32(items[0]);
            int id = Convert.ToInt32(items[1]);
            var allProducts = new List<Product>();
            var resultListProduct = new List<Product>();

            foreach (var prod in db.Products.ToList())
            {
                if (productCategory == 1)
                {
                    if (prod.ProductType.Equals("Телевизор")
                        || prod.ProductType.Equals("ТВ")
                        || prod.ProductType.Equals("TV"))
                    {
                        allProducts.Add(prod);
                    }
                }

                if (productCategory == 2)
                {
                    if (prod.ProductType.Equals("Смартфон")
                        || prod.ProductType.Equals("Телефон")
                        || prod.ProductType.Equals("Smartphone"))
                    {
                        allProducts.Add(prod);
                    }
                }

                if (productCategory == 3)
                {
                    if (prod.ProductType.Equals("Компьютер")
                        || prod.ProductType.Equals("Ноутбук")
                        || prod.ProductType.Equals("Сomputer"))
                    {
                        allProducts.Add(prod);
                    }
                }

                if (productCategory == 4)
                {
                    if (prod.ProductType.Equals("Бытовая техника")
                        || prod.ProductType.Equals("БТ")
                        || prod.ProductType.Equals("Appliances"))
                    {
                        allProducts.Add(prod);
                    }
                }

                if (productCategory == 5)
                {
                    if (prod.ProductType.Equals("Фотоаппарат")
                        || prod.ProductType.Equals("Камера")
                        || prod.ProductType.Equals("Видеокамера")
                        || prod.ProductType.Equals("Camera"))
                    {
                        allProducts.Add(prod);
                    }
                }
            }

            float countProductsOnOnePage = 12f;

            int count = (int)Math.Ceiling((decimal)(allProducts.Count / countProductsOnOnePage));
            ViewBag.PagesCount = count;

            int length = 0;

            if ((id * countProductsOnOnePage) > allProducts.Count)
            {
                length = allProducts.Count;
            }
            else
            {
                length = (int)(id * countProductsOnOnePage);
            }
            for (int i = (int)(id * countProductsOnOnePage - countProductsOnOnePage); i < length; i++)
            {
                if (allProducts[i].IsDeleted != true)
                {
                    resultListProduct.Add(allProducts[i]);
                }
            }
            return View(resultListProduct);
        }

    }
}
