using Microsoft.AspNetCore.Mvc;

namespace DIWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}