using CarBook_Ayt_Dto.BannerDtos;
using CarBook_Ayt_Dto.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookWebCoreUI.Controllers
{
    public class AdminCategoryController : Controller
    {
        private readonly IHttpClientFactory _httpclientfactory;

        public AdminCategoryController(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory = httpclientfactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpclientfactory.CreateClient();

            var response = await client.GetAsync("http://localhost:5013/api/Categorys");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCategory()

        {

            return View(new CreateCategoryDto());
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)

        {
            var client = _httpclientfactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createCategoryDto);

            StringContent stringContent =
                new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage =
                await client.PostAsync("http://localhost:5013/api/Categorys/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(createCategoryDto);
        }
        public async Task<IActionResult> RemoveCategory(int id)
        {
            var client = _httpclientfactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5013/api/Categorys/{id}");
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
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpclientfactory.CreateClient();

            var responseMessage = await client.GetAsync($"http://localhost:5013/api/Categorys/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData =
                    await responseMessage.Content.ReadAsStringAsync();

                var values =
                    JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);

                if (values == null)
                {
                    return RedirectToAction("Index");
                }

                return View(values);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpclientfactory.CreateClient();

            var jsonData =
                JsonConvert.SerializeObject(updateCategoryDto);

            StringContent stringContent =
                new StringContent(
                    jsonData,
                    Encoding.UTF8,
                    "application/json");


            var responseMessage =
                await client.PutAsync(
                    "http://localhost:5013/api/Categorys",
                    stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            var errorMessage =
                await responseMessage.Content.ReadAsStringAsync();

            ViewBag.Error = errorMessage;

            return View(updateCategoryDto);
        }
    }
}
