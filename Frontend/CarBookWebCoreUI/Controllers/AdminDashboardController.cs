using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.Controllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
