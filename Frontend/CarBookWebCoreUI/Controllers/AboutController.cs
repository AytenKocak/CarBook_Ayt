using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.V1 = "Hakkımızda";
            ViewBag.V2 = "Misyonumuz";
            
             
           return View();
            
        }
    }
}
