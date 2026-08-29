using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailTabPaneComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }   
    }
}
