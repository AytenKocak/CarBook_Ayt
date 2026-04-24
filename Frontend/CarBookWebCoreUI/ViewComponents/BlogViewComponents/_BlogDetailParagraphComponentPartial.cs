using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailParagraphComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
