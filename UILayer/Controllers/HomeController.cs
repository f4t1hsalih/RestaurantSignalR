using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
