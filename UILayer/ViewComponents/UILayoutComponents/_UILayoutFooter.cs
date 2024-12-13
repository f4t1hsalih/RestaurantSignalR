using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooter:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
