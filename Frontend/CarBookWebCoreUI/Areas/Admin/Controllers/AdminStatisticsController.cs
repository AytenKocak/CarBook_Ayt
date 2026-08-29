using CarBook_Ayt_Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace CarBookWebCoreUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index ()
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

            #region Brand Count
            var responseMessage5 = await client.GetAsync("http://localhost:5013/api/Statistics/GetBrandCount");

            if (responseMessage5.IsSuccessStatusCode)
            {
                int brandCountRandom = random.Next(0, 101);
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultsStatisticsDtos>(jsonData5);
                ViewBag.BrandCount = values5.BrandCount;
                ViewBag.brandCountRandom = brandCountRandom;
            }
            #endregion

            #region AvrgRentPriceForDaily

            var responseMessage6 = await client.GetAsync("http://localhost:5013/api/Statistics/GetAvrgRentPriceForDaily");

            if (responseMessage6.IsSuccessStatusCode)
            {
                int AvrgRentPriceForDailyRandom = random.Next(0, 101);
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultsStatisticsDtos>(jsonData6);               
                ViewBag.AvrgRentPriceForDaily = values6.avrgRentPriceForDaily;
                ViewBag.AvrgRentPriceForDailyRandom = AvrgRentPriceForDailyRandom;
            }
            #endregion

            #region AvrgRentPriceForWeekly

            var responseMessage7 = await client.GetAsync("http://localhost:5013/api/Statistics/GetAvrgRentPriceForWeekly");

            if (responseMessage7.IsSuccessStatusCode)
            {
                int AvrgRentPriceForWeeklyRandom = random.Next(0, 101);
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultsStatisticsDtos>(jsonData7);
                ViewBag.AvrgRentPriceForWeekly = values7.avrgRentPriceForWeekly;
                ViewBag.AvrgRentPriceForWeeklyRandom = AvrgRentPriceForWeeklyRandom;
            }
            #endregion

            #region AvrgRentPriceForMountly

            var responseMessage8 = await client.GetAsync("http://localhost:5013/api/Statistics/GetAvrgRentPriceForMountly");

            if (responseMessage8.IsSuccessStatusCode)
            {
                int AvrgRentPriceForMountlyRandom = random.Next(0, 101);
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultsStatisticsDtos>(jsonData8);
                ViewBag.avrgRentPriceForMountly = values8.avrgRentPriceForMountly;
                ViewBag.AvrgRentPriceForMountlyRandom = AvrgRentPriceForMountlyRandom;
            }
            #endregion

            #region GetCarCountByTransmissionIsAuto
            var responseMessage9 = await client.GetAsync("http://localhost:5013/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                int CarCountByTransmissionIsAutoRandom = random.Next(0, 101);
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultsStatisticsDtos>(jsonData9);  
                ViewBag.CarCountByTransmissionIsAuto = values9.carCountByTransmissionIsAuto;
                ViewBag.CarCountByTransmissionIsAutoRandom = CarCountByTransmissionIsAutoRandom;    


            }
            #endregion

            #region GetCarCountSmallerThan1000
            var responseMessage12 = await client.GetAsync("http://localhost:5013/api/Statistics/GetCarCountSmallerThan1000");
            if(responseMessage12.IsSuccessStatusCode)
            {
                int CarCountSmallerThan1000Random = random.Next(0, 101);
                var jsondata12 = await responseMessage12.Content.ReadAsStringAsync();
                var values12 = JsonConvert.DeserializeObject<ResultsStatisticsDtos>(jsondata12);
                ViewBag.CarCountSmallerThan1000 = values12.CarCountSmallerThan1000;
                ViewBag.CarCountSmallerThan1000Random = CarCountSmallerThan1000Random;


            }
            #endregion

            #region GetCarCountByGasolineOrDisel
            var responseMessage13 = await client.GetAsync("http://localhost:5013/api/Statistics/GetCarCountByGasolineOrDisel");
            if (responseMessage13.IsSuccessStatusCode)
            {
                int CarCountByGasolineOrDiselRandom = random.Next(0, 101);
                var jsondata13 = await responseMessage13.Content.ReadAsStringAsync();
                var values13 = JsonConvert.DeserializeObject<ResultsStatisticsDtos>(jsondata13);
                ViewBag.CarCountByGasolineOrDisel = values13.CarCountByGasolineOrDisel;
                ViewBag.CarCountByGasolineOrDiselRandom = CarCountByGasolineOrDiselRandom;


            }
            #endregion

            #region GetCarCountByElectiric
            var responseMessage14 = await client.GetAsync("http://localhost:5013/api/Statistics/GetCarCountByElectiric");
            if (responseMessage14.IsSuccessStatusCode)
            {
                int CarCountByElectiricRandom = random.Next(0, 101);
                var jsondata14 = await responseMessage14.Content.ReadAsStringAsync();
                var values14 = JsonConvert.DeserializeObject<ResultsStatisticsDtos>(jsondata14);
                ViewBag.CarCountByElectiric = values14.CarCountByElectiric;
                ViewBag.CarCountByElectiricRandom = CarCountByElectiricRandom;


            }
            #endregion
            #region
            var responseMessage15 = await client.GetAsync("http://localhost:5013/api/Statistics/GetBrandNameByMaxCar");
            if (responseMessage15.IsSuccessStatusCode)
            {
                int BrandNameByMaxCarRandom = random.Next(0, 101);
                var jsondata15 = await responseMessage15.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<ResultsStatisticsDtos>(jsondata15);
                ViewBag.BrandNameByMaxCar = values15.BrandNameByMaxCar;
                ViewBag.BrandNameByMaxCarRandom = BrandNameByMaxCarRandom;


            }
            #endregion
            #region
            var responseMessage16 = await client.GetAsync("http://localhost:5013/api/Statistics/GetBlogTitleByMaxComment");
            if (responseMessage16.IsSuccessStatusCode)
            {
                int BlogTitleByMaxCommentRandom = random.Next(0, 101);
                var jsondata16 = await responseMessage16.Content.ReadAsStringAsync();
                var values16 = JsonConvert.DeserializeObject<ResultsStatisticsDtos>(jsondata16);
                ViewBag.BlogTitleByMaxComment = values16.BlogTitleByMaxComment;
                ViewBag.BlogTitleByMaxCommentRandom = BlogTitleByMaxCommentRandom;


            }

            #endregion
            return View();
        }
    }
}

