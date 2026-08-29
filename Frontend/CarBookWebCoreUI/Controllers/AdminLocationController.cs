using CarBook_Ayt_Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookWebCoreUI.Controllers
{
    public class AdminLocationController : Controller
    {
        private readonly IHttpClientFactory _httpclientfactory;

        public AdminLocationController(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory = httpclientfactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpclientfactory.CreateClient();

            var response = await client.GetAsync("http://localhost:5013/api/Locations");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateLocation()
        {

            return View(new CreateLocationDto());
        }


        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)

        {
            var client = _httpclientfactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createLocationDto);

            StringContent stringContent =
                new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage =
                await client.PostAsync("http://localhost:5013/api/Locations/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(createLocationDto);
        }
        public async Task<IActionResult> RemoveLocation(int id)
        {
            var client = _httpclientfactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5013/api/Locations/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            // API hata mesajını al
            var errorMessage = await responseMessage.Content.ReadAsStringAsync();

            ViewBag.Error = errorMessage;
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var client = _httpclientfactory.CreateClient();

            var responseMessage = await client.GetAsync($"http://localhost:5013/api/Locations/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData =
                    await responseMessage.Content.ReadAsStringAsync();

                var values =
                    JsonConvert.DeserializeObject<UpdateLocationDto>(jsonData);

                if (values == null)
                {
                    return RedirectToAction("Index");
                }

                return View(values);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            var client = _httpclientfactory.CreateClient();

            var jsonData =
                JsonConvert.SerializeObject(updateLocationDto);

            StringContent stringContent =
                new StringContent(
                    jsonData,
                    Encoding.UTF8,
                    "application/json");


            var responseMessage =
                await client.PutAsync(
                    "http://localhost:5013/api/Locations",
                    stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            var errorMessage =
                await responseMessage.Content.ReadAsStringAsync();

            ViewBag.Error = errorMessage;

            return View(updateLocationDto);
        }
    }
}