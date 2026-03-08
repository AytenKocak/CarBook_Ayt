using CarBook_Ayt_Dto.BlogDtos;
using CarBook_Ayt_Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebCoreUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.V1= "Blog Listesi";
            ViewBag.V2="Yazarlarımızın Blogları";
            var client = _httpClientFactory.CreateClient("");
            var responseMessage = await client.GetAsync("http://localhost:5013/api/Blog/GetAllBlogsWithAuthorList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
                return View(values ?? new List<ResultAllBlogsWithAuthorDto>());
            }



            return View(new List<ResultAllBlogsWithAuthorDto>());
        }
        //Blogdetail için
        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.V1 = "Blog Listesi";
            ViewBag.V2 = "Blog Detayı";
            return View();
        }
    }
}