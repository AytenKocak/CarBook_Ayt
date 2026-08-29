using CarBook_Ayt_Dto.BrandDtos;
using CarBook_Ayt_Dto.CarDtos;
using CarBook_Ayt_Dto.CarFeatureDtos;
using CarBook_Ayt_Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBookWebCoreUI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpclientfactory;

        public AdminCarController(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory = httpclientfactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpclientfactory.CreateClient();

            var response = await client.GetAsync("http://localhost:5013/api/Cars/GetCarWithBrand");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGetCarWithBrand>>(jsonData);
                return View(values);
            }
            return View(new List<ResultGetCarWithBrand>());
        }
        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpclientfactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5013/api/Brands");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
            List<SelectListItem> brandValues = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.BrandID.ToString()

                                                }).ToList();
            ViewBag.BrandValues = brandValues;


            return View();


        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var client = _httpclientfactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createCarDto);

            StringContent stringContent =
                new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage =
                await client.PostAsync("http://localhost:5013/api/Cars/", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            // API hata mesajını al
            var errorMessage = await responseMessage.Content.ReadAsStringAsync();

            ViewBag.Error = errorMessage;

            // Dropdown tekrar dolduruluyor
            var response =
                await client.GetAsync("http://localhost:5013/api/Brands");

            var json =
                await response.Content.ReadAsStringAsync();

            var values =
                JsonConvert.DeserializeObject<List<ResultBrandDto>>(json);

            List<SelectListItem> brandValues = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.BrandID.ToString()
                                                }).ToList();

            ViewBag.BrandValues = brandValues;

            return View(createCarDto);
        }
        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpclientfactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5013/api/Cars/{id}");
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
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpclientfactory.CreateClient();

            var responseMessage =
                await client.GetAsync($"http://localhost:5013/api/Cars/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData =
                    await responseMessage.Content.ReadAsStringAsync();

                var values =
                    JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);

                // Brand dropdown
                var brandResponse =
                    await client.GetAsync("http://localhost:5013/api/Brands");

                var brandJson =
                    await brandResponse.Content.ReadAsStringAsync();

                var brandValues =
                    JsonConvert.DeserializeObject<List<ResultBrandDto>>(brandJson);

                List<SelectListItem> brands = (from x in brandValues
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.BrandID.ToString()
                                               }).ToList();

                ViewBag.BrandValues = brands;

                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var client = _httpclientfactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateCarDto);

            StringContent stringContent =
                new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage =
                await client.PutAsync(
                    $"http://localhost:5013/api/Cars/{updateCarDto.CarID}",
                    stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            var brandResponse =
       await client.GetAsync("http://localhost:5013/api/Brands");

            var brandJson =
                await brandResponse.Content.ReadAsStringAsync();

            var brandValues =
                JsonConvert.DeserializeObject<List<ResultBrandDto>>(brandJson);

            ViewBag.BrandValues = brandValues.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.BrandID.ToString()
            }).ToList();
            return View(updateCarDto);

        }
        [HttpGet]
        public IActionResult AdminCarDetail( int id)
        {
            return View();


        }
     

    }
}
