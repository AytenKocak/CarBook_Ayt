using CarBook_Ayt_Dto.AuthorDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookWebCoreUI.Controllers
{
    public class AdminAuthorController : Controller
    {
        private readonly IHttpClientFactory _httpclientfactory;

        public AdminAuthorController(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory = httpclientfactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpclientfactory.CreateClient();

            var response = await client.GetAsync("http://localhost:5013/api/Author");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAuthorDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateAuthor()
        {

            return View(new CreateAuthorDto());
        }


        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDto createAuthorDto)

        {
            var client = _httpclientfactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createAuthorDto);

            StringContent stringContent =
                new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage =
                await client.PostAsync("http://localhost:5013/api/Author/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(createAuthorDto);
        }
        public async Task<IActionResult> RemoveAuthor(int id)
        {
            var client = _httpclientfactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5013/api/Author/{id}");
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
        public async Task<IActionResult> UpdateAuthor(int id)
        {
            var client = _httpclientfactory.CreateClient();

            var responseMessage = await client.GetAsync($"http://localhost:5013/api/Author/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData =
                    await responseMessage.Content.ReadAsStringAsync();

                var values =
                    JsonConvert.DeserializeObject<UpdateAuthorDto>(jsonData);

                if (values == null)
                {
                    return RedirectToAction("Index");
                }

                return View(values);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto updateAuthorDto)
        {
            var client = _httpclientfactory.CreateClient();

            var jsonData =
                JsonConvert.SerializeObject(updateAuthorDto);

            StringContent stringContent =
                new StringContent(
                    jsonData,
                    Encoding.UTF8,
                    "application/json");


            var responseMessage =
                await client.PutAsync(
                    "http://localhost:5013/api/Author",
                    stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            var errorMessage =
                await responseMessage.Content.ReadAsStringAsync();

            ViewBag.Error = errorMessage;

            return View(updateAuthorDto);
        }
    }
}
