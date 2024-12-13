using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.UILayoutComponents
{
    public class _UILayoutScripts : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
