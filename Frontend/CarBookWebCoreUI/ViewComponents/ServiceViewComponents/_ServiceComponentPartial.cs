using CarBook_Ayt_Dto.BannerDtos;
using CarBook_Ayt_Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebCoreUI.ViewComponents.ServiceViewComponents
{
    public class _ServiceComponentPartial:ViewComponent
    {
        public readonly IHttpClientFactory _httpClientFactory;

        public _ServiceComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5013/api/Services");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jasonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jasonData);
                return View(values);
            }


            return View();
           
        }
    }
}
