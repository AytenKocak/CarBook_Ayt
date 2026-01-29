using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
