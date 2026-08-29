using CarBook_Ayt_Dto.CarFeatureDtos;
using CarBook_Ayt_Dto.FeatureDtos;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookWebCoreUI.Controllers
{
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5013/api/CarFeatures?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
        {
            var client = _httpClientFactory.CreateClient();

            foreach (var item in resultCarFeatureByCarIdDto)
            {
                if (item.Available)
                {
                    await client.GetAsync(
                        "http://localhost:5013/api/CarFeatures/CarFeatureChangeAvaliableToTrue?id="
                        + item.CarFeatureID);
                }
                else
                {
                    await client.GetAsync(
                        "http://localhost:5013/api/CarFeatures/CarFeatureChangeAvaliableToFalse?id="
                        + item.CarFeatureID);
                }
            }

            return RedirectToAction(
         "Index",
         "AdminCarFeatureDetail", new { id = resultCarFeatureByCarIdDto.First().CarID });


        }
        [HttpGet]
        public async Task <IActionResult> CreateFeatureByCarId()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5013/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }




    }


 }


