using CarBook_Ayt_Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebCoreUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.V1 = "Hizmetler";
            ViewBag.V2 = "Hizmetlerimiz";

            return View();

        }
    }
}