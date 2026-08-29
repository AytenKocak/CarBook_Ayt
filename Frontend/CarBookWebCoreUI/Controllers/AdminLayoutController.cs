using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
       public PartialViewResult AdminHeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult AdminNawBarPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminSideBarPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminFooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult AdminScriptPartial()
        {
            return PartialView();
        }
    }
}
