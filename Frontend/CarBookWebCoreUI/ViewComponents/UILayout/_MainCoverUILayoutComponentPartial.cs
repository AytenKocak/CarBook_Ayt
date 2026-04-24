using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.ViewComponents.UILayout
{
    public class _MainCoverUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
