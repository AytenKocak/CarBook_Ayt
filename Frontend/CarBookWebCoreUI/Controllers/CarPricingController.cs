using CarBook.Application.ViewModels;
using CarBook_Ayt_Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebCoreUI.Controllers
{
    public class CarPricingController : Controller
    {
        
        private readonly IHttpClientFactory _httpClientFactory;

        public CarPricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.V1 = "Paketler";
            ViewBag.V2 = "Araç Fiyat Paketleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5013/api/CarPricings/GetCarPricingWithTimePeriod");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<CarPricingListWithModelDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
