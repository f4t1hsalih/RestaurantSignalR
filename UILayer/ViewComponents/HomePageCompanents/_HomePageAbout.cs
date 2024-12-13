using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.HomePageCompanents
{
    public class _HomePageAbout : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
