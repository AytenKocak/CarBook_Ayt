using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.ViewComponents.UILayout
{
    public class _NavbarUILayoutComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
