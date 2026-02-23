using CarBook_Ayt_Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebCoreUI.Controllers
{
    public class ServiceController : Controller
    {
       

        public IActionResult Index()        
        { return View();

        }
    }
}