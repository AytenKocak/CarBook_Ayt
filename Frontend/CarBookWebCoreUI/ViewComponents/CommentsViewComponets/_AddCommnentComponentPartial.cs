using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.ViewComponents.CommentsViewComponets
{
    public class _AddCommnentComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
