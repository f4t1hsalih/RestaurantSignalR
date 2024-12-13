using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
