using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.HomePageCompanents
{
    public class _HomePageBookTable : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
