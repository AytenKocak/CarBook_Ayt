using CarBook_Ayt_Dto.CreateContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookWebCoreUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            var client = _httpClientFactory.CreateClient("CarBookClient");

            createContactDto.SendDate = DateTime.Now;

            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringcontent =
                new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage =
                await client.PostAsync("api/Contacts", stringcontent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Car");
            }

            return View();
        }
    }
}
