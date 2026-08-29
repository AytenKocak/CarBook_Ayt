using CarBook_Ayt_Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace CarBookWebCoreUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
          
            var responseMessage = await client.GetAsync("http://localhost:5013/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)

            {
               
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<ResultsStatisticsDtos>(jsonData);
                ViewBag.CarCaunt = values1.carCount;
          

            }
         
            var responseMessage2 = await client.GetAsync("http://localhost:5013/api/Statistics/GetLocationCount");

            if (responseMessage2.IsSuccessStatusCode)
            {
            
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultsStatisticsDtos>(jsonData2);
                ViewBag.locationCount = values2.locationCount;
            
            }
           
            var responseMessage3 = await client.GetAsync("http://localhost:5013/api/Statistics/GetBrandCount");

            if (responseMessage3.IsSuccessStatusCode)
            {
           
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultsStatisticsDtos>(jsonData3);
                ViewBag.BrandCount = values3.BrandCount;
       
            }

            //var responseMessage4 = await client.GetAsync("http://localhost:5013/api/Statistics/GetBrandNameByMaxCar");
            //if (responseMessage4.IsSuccessStatusCode)
            //{
               
            //    var jsondata4 = await responseMessage4.Content.ReadAsStringAsync();
            //    var values4 = JsonConvert.DeserializeObject<ResultsStatisticsDtos>(jsondata4);
            //    ViewBag.BrandNameByMaxCar = values4.BrandNameByMaxCar;
                


            //}
          
            var responseMessage5 = await client.GetAsync("http://localhost:5013/api/Statistics/GetCarCountSmallerThan1000");
            if (responseMessage5.IsSuccessStatusCode)
            {
               
                var jsondata5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultsStatisticsDtos>(jsondata5);
                ViewBag.CarCountSmallerThan1000 = values5.CarCountSmallerThan1000;
           


            }
      




            return View();
        }
    }
}
