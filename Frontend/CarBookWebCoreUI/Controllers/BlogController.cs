using CarBook_Ayt_Dto.BlogDtos;
using CarBook_Ayt_Dto.CarPricingDtos;
using CarBook_Ayt_Dto.CommentDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System.Text;

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
            var responseMessage = await client.GetAsync("http://localhost:5013/api/Blogs/GetAllBlogsWithAuthorList");
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
            ViewBag.blogid = id;

            var client = _httpClientFactory.CreateClient();

            var responseMessage2 = await client.GetAsync(
                $"http://localhost:5013/api/Comments/GetCountCommentByBlog?id={id}");

            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

            ViewBag.commentCount = jsonData2;

            return View();
        }
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommandDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createCommandDto);

            StringContent stringContent = new StringContent(
                jsonData,
                Encoding.UTF8,
                "application/json"
            );

            var responseMessage = await client.PostAsync(
                "http://localhost:5013/api/Comments/CreateCommentWithMediator",
                stringContent
            );

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");

            }

            return View(createCommandDto);
        }


    }
}