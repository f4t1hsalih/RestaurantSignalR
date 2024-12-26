using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
