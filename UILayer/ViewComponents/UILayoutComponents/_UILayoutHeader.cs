using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.UILayoutComponents
{
    public class _UILayoutHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
