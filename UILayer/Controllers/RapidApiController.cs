using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class RapidApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
