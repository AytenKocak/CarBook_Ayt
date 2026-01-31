using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.ViewComponents.AboutViewComponents
{
    public class _BeComeAdriverComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
