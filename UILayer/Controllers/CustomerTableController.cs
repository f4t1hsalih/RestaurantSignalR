using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
    public class CustomerTableController : Controller
    {
        public IActionResult CustomerTableList()
        {
            return View();
        }
    }
}
