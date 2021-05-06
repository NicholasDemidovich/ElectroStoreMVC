using ElectroStoreMVC.Models;
using ElectroStoreMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectroStoreMVC.Controllers
{
    public class PersonalAreaController : Controller
    {
        StoreContext db;
        public PersonalAreaController(StoreContext context)
        {
            db = context;
        }

        [Authorize]
        public IActionResult PersonalRoom()
        {
            var orderUR = new OrderURViewModel();

            var userReviews = new List<UserReviewViewModel>();
            
            var orderProductViewModels = new List<OrderProductViewModel>();
            User user = new User();

            string name = User.Identity.Name;
            var us = db.Users.Where(u => u.UserName == name);
            user = us.First();
            ViewBag.User = user;

            var or = db.Orders.Where(o => o.UserId == user.Id);
            foreach(var order in or.AsEnumerable())
            {
                var orderProduct = new OrderProductViewModel();
                orderProduct.Order = order;
                orderProduct.Product = db.Products.Find(order.ProductId);

                orderProductViewModels.Add(orderProduct);
            }

            foreach (var ur in db.UserReviews.ToList())
            {
                var urVM = new UserReviewViewModel();
                string tempName = db.Users.Find(ur.UserId).UserName;

                urVM.UserName = tempName;
                urVM.UserReview = ur;

                userReviews.Add(urVM);
            }

            orderUR.OrderProductViewModels = orderProductViewModels;
            orderUR.UserReviewViewModel = userReviews;

            return View(orderUR);
        }

        [HttpPost]
        public IActionResult PersonalRoom(User user)
        {
            string name = User.Identity.Name;
            var us = db.Users.Where(u => u.UserName == name).First();

            us.PhoneNumber = user.PhoneNumber != null ? user.PhoneNumber : us.PhoneNumber;
            us.Email = user.Email != null ? user.Email : us.Email;
            us.Address = user.Address != null ? user.Address : us.Address;

            db.SaveChanges();

            return Redirect("~/PersonalArea/PersonalRoom");
        }
    }
}
