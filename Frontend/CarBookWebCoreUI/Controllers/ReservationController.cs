using CarBook_Ayt_Dto.LocationDtos;
using CarBook_Ayt_Dto.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace CarBookWebCoreUI.Controllers
{
    public class ReservationController : Controller
    {
           private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
      
        [HttpGet("Reservation/Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.V3 = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5013/api/Locations");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

            ViewBag.LocationList = values.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.LocationID.ToString()
            }).ToList();

            CreateReservationDto dto = new CreateReservationDto
            {
                CarID = id
            };

            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage=await client.PostAsync("http://localhost:5013/api/Reservations", 
                stringContent); 
            if (responseMessage.IsSuccessStatusCode)
            {

               return RedirectToAction("Index", "Default" );

            }
            return View();
             
        }
    }
}
