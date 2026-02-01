using CarBook_Ayt_Dto.AboutDtos;
using CarBook_Ayt_Dto.CarDtos;
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
            var client = _httpClientFactory.CreateClient("CarBookClient");
            var responseMessage = await client.GetAsync("Cars");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData);
                return View(values ?? new List<ResultCarDto>());
            }



            return View( new List <ResultCarDto>());
        }
    }
}
