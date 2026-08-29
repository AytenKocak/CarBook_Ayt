using CarBook_Ayt_Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookWebCoreUI.Controllers
{
    public class AdminServiceController : Controller
    {
        private readonly IHttpClientFactory _httpclientfactory;

        public AdminServiceController(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory = httpclientfactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpclientfactory.CreateClient();

            var response = await client.GetAsync("http://localhost:5013/api/Services");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateService()
        {

            return View(new CreateServiceDto());
        }


        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)

        {
            var client = _httpclientfactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createServiceDto);

            StringContent stringContent =
                new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage =
                await client.PostAsync("http://localhost:5013/api/Services/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(createServiceDto);
        }
        public async Task<IActionResult> RemoveService(int id)
        {
            var client = _httpclientfactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5013/api/Services/{id}");
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
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpclientfactory.CreateClient();

            var responseMessage = await client.GetAsync($"http://localhost:5013/api/Services/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData =
                    await responseMessage.Content.ReadAsStringAsync();

                var values =
                    JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);

                if (values == null)
                {
                    return RedirectToAction("Index");
                }

                return View(values);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            var client = _httpclientfactory.CreateClient();

            var jsonData =
                JsonConvert.SerializeObject(updateServiceDto);

            StringContent stringContent =
                new StringContent(
                    jsonData,
                    Encoding.UTF8,
                    "application/json");


            var responseMessage =
                await client.PutAsync(
                    "http://localhost:5013/api/Services",
                    stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            var errorMessage =
                await responseMessage.Content.ReadAsStringAsync();

            ViewBag.Error = errorMessage;

            return View(updateServiceDto);
        }
    }
}
