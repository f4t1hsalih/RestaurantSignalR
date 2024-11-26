using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.LayoutComponents
{
    public class _LayoutFooter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
