using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.V1 = "Hizmetler";
            {
                ViewBag.V2 = "Hizmetlerimiz";
                return View();
            }
        }
    }
}
