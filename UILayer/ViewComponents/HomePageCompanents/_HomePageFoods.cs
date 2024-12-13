using Microsoft.AspNetCore.Mvc;

namespace UILayer.ViewComponents.HomePageCompanents
{
    public class _HomePageFoods : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
