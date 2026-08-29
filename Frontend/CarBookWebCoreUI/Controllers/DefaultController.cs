using CarBook_Ayt_Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBookWebCoreUI.Controllers
{
    public class DefaultController : Controller
    {


        private readonly IHttpClientFactory _httpclientfactory;

        public DefaultController(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory = httpclientfactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var client = _httpclientfactory.CreateClient();

            var response = await client.GetAsync("http://localhost:5013/api/Locations");


            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
            List<SelectListItem> locationList = values.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.LocationID.ToString()
            }).ToList();

            ViewBag.LocationList = locationList;
            return View();

        }
        [HttpPost]
        public IActionResult Index(string book_pick_date,string book_off_date,string time_pick,string time_off,string LocationID)
        {
            TempData["bookpickdate"] = book_pick_date;
            TempData["bookoffdate"] = book_off_date;
            TempData["timepick"] = time_pick;
            TempData["time_off"] = time_off;
            TempData["LocationID"] = LocationID;
            return RedirectToAction("Index","RentACarList");
        }

    } 
}

