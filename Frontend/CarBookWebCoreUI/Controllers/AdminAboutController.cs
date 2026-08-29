using CarBook_Ayt_Dto.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookWebCoreUI.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IHttpClientFactory _httpclientfactory;

        public AdminAboutController(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory = httpclientfactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpclientfactory.CreateClient();

            var response = await client.GetAsync("http://localhost:5013/api/Abouts");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateAbout()
        {

            return View(new CreateAboutDto());
        }


        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)

        {
            var client = _httpclientfactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createAboutDto);

            StringContent stringContent =
                new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage =
                await client.PostAsync("http://localhost:5013/api/Abouts/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(createAboutDto);
        }
        public async Task<IActionResult> RemoveAbout(int id)
        {
            var client = _httpclientfactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5013/api/Abouts/{id}");
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
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpclientfactory.CreateClient();

            var responseMessage = await client.GetAsync($"http://localhost:5013/api/Abouts/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData =
                    await responseMessage.Content.ReadAsStringAsync();

                var values =
                    JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);

                if (values == null)
                {
                    return RedirectToAction("Index");
                }

                return View(values);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var client = _httpclientfactory.CreateClient();

            var jsonData =
                JsonConvert.SerializeObject(updateAboutDto);

            StringContent stringContent =
                new StringContent(
                    jsonData,
                    Encoding.UTF8,
                    "application/json");


            var responseMessage =
                await client.PutAsync(
                    "http://localhost:5013/api/Abouts",
                    stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            var errorMessage =
                await responseMessage.Content.ReadAsStringAsync();

            ViewBag.Error = errorMessage;

            return View(updateAboutDto);
        }
    }
}