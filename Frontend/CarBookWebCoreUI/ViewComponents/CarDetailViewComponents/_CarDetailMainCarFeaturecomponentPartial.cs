using CarBook_Ayt_Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebCoreUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailMainCarFeaturecomponentPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailMainCarFeaturecomponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.carid = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5013/api/Cars/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultGetCarWithBrand>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
