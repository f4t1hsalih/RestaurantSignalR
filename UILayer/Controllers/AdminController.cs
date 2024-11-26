using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
