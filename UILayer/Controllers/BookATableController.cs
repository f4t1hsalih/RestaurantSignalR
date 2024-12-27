using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class BookATableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
