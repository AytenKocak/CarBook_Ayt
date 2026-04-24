using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.ViewComponents.CommentsViewComponets
{
    public class CommentsListByBlogComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
