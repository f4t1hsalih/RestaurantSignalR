using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound404Page()
        {
            return View();
        }
    }
}
