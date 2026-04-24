using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
