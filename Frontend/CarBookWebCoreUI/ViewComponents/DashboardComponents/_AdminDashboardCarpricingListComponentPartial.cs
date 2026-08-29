using CarBook_Ayt_Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebCoreUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardCarpricingListComponentPartial:ViewComponent
    {  private readonly IHttpClientFactory _httpClientFactory;
        public _AdminDashboardCarpricingListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
       public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag. V1 = "Paketler";
            ViewBag. V2 = "Araç Paket Fiyatları";


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5013/api/CarPricings/GetCarPricingWithTimePeriod");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CarPricingListWithModelDto>>(jsonData);
                return View(values);
            }
            return View();
        }


    }
}
