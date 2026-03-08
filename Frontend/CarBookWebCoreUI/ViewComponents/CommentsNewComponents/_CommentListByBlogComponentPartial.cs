using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.ViewComponents.CommentsNewComponents
{
    public class _CommentListByBlogComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
