using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailDescriptionComponentPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
