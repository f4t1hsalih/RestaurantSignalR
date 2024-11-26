using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
