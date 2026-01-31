using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.ViewComponents.UILayout
{
    public class _ScriptUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
    
}
