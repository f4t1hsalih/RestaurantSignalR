using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.LayoutComponents
{
    public class _LayoutSidebar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
