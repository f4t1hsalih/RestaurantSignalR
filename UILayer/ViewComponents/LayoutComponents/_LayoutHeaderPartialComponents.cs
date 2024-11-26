using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderPartialComponents : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
