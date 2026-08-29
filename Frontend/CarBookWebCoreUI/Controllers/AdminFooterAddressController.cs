using CarBook_Ayt_Dto.FooterAdressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBookWebCoreUI.Controllers
{
    public class AdminFooterAddressController : Controller
    {
        private readonly IHttpClientFactory _httpclientfactory;

        public AdminFooterAddressController(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory = httpclientfactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpclientfactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5013/api/FooterAddresses");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);
                return View(values);
            }

            // API'den veri gelmezse sayfa çökmesin diye boş liste gönderiyoruz
            return View(new List<ResultFooterAddressDto>());
        }

        [HttpGet]
        public IActionResult CreateFooterAddress()
        {
            return View(new CreateFooterAddressDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressDto createFooterAdressDto)
        {
            var client = _httpclientfactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFooterAdressDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("http://localhost:5013/api/FooterAddresses/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(createFooterAdressDto);
        }

        // HATA DÜZELTİLDİ: Metot adı View ile uyumlu olması için DeleteFooterAddress yapıldı.
        public async Task<IActionResult> DeleteFooterAddress(int id)
        {
            var client = _httpclientfactory.CreateClient();

            // HATA DÜZELTİLDİ: Birbirine giren çorba URL temizlendi.
            var responseMessage = await client.DeleteAsync($"http://localhost:5013/api/FooterAddresses/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            var errorMessage = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.Error = errorMessage;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFooterAddress(int id)
        {
            var client = _httpclientfactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5013/api/FooterAddresses/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFooterAddressDto>(jsonData);

                if (values == null)
                {
                    return RedirectToAction("Index");
                }

                return View(values);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressDto updateFooterAdressDto)
        {
            var client = _httpclientfactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFooterAdressDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("http://localhost:5013/api/FooterAddresses", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            var errorMessage = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.Error = errorMessage;

            return View(updateFooterAdressDto);
        }
    }
}
