using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
