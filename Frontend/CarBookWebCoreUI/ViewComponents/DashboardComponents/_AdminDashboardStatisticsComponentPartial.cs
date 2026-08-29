using CarBook_Ayt_Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebCoreUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();
            #region Car Count
            var responseMessage = await client.GetAsync("http://localhost:5013/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)

            {
                int v1 = random.Next(0, 101);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<ResultsStatisticsDtos>(jsonData);
                ViewBag.v = values1.carCount;
                ViewBag.v1 = v1;

            }
            #endregion

            #region Location Count
            var responseMessage2 = await client.GetAsync("http://localhost:5013/api/Statistics/GetLocationCount");

            if (responseMessage2.IsSuccessStatusCode)
            {
                int locationCountRandom = random.Next(0, 101);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultsStatisticsDtos>(jsonData2);
                ViewBag.locationCount = values2.locationCount;
                ViewBag.locationCountRandom = locationCountRandom;
            }
            #endregion

            #region Authour Count
            var responseMessage3 = await client.GetAsync("http://localhost:5013/api/Statistics/GetAuthourCount");

            if (responseMessage3.IsSuccessStatusCode)
            {
                int authourCountRandom = random.Next(0, 101);
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultsStatisticsDtos>(jsonData3);
                ViewBag.authourCount = values3.authourCount;
                ViewBag.authourCountRandom = authourCountRandom;
            }
            #endregion

            #region Blog Count
            var responseMessage4 = await client.GetAsync("http://localhost:5013/api/Statistics/GetBlogCount");

            if (responseMessage4.IsSuccessStatusCode)
            {
                int blogCountRandom = random.Next(0, 101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultsStatisticsDtos>(jsonData4);
                ViewBag.blogCount = values4.blogCount;
                ViewBag.blogCountRandom = blogCountRandom;
            }
            #endregion



            return View();
        }
    }
}
