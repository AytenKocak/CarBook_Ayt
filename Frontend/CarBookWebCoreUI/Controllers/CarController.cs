using CarBook_Ayt_Dto.AboutDtos;
using CarBook_Ayt_Dto.CarDtos;
using CarBook_Ayt_Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebCoreUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task < IActionResult >Index()
        {
            var client = _httpClientFactory.CreateClient("");
            var responseMessage = await client.GetAsync("http://localhost:5013/api/Cars/GetCarWithPricing");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(jsonData);
                return View(values ?? new List<ResultCarPricingWithCarDto>());
            }



            return View( new List <ResultCarPricingWithCarDto>());
        }
    }
}
