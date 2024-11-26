using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.LayoutComponents
{
    public class _LayoutNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
