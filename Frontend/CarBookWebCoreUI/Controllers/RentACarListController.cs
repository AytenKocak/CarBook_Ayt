using CarBook_Ayt_Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookWebCoreUI.Controllers
{
    public class RentACarListController : Controller
    {  private readonly IHttpClientFactory _httpclientfactory;

        public RentACarListController(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory = httpclientfactory;
        }

        public async Task< IActionResult> Index(int id)
        {
            var bookpickdate = TempData["bookpickdate"];
            var bookoffdate = TempData["bookoffdate"];
            var timepick = TempData["timepick"];
            var time_off = TempData["time_off"];
            var LocationID = TempData["LocationID"];
            //filterRentACarDto.LocationID = Convert.ToInt32(LocationID);
            //filterRentACarDto.Avaliable = true;
            id = int.Parse(LocationID.ToString());



            ViewBag.bookpickdate = bookpickdate;
            ViewBag.bookoffdate = bookoffdate;
            ViewBag.timepick = timepick;
            ViewBag.time_off = time_off;
            ViewBag.LocationID = LocationID;

            var client = _httpclientfactory.CreateClient();        
                  
            var responseMessage = await client.GetAsync($"http://localhost:5013/api/RentACar?locationID={id}&avaliable=true");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);
                   
            }

            return View();


           
        }
    }
}
