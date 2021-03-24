using Microsoft.AspNetCore.Mvc;

namespace ElectroStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
