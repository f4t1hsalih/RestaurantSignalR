using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.LayoutComponents
{
    public class _LayoutHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
