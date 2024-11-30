using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class SignalRDefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
