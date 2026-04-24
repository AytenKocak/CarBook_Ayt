using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.ViewComponents.UILayout
{
    public class _HeadUILayoutComponentPartial :ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
