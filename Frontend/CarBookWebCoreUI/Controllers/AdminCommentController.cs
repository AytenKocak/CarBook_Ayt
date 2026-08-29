using CarBook_Ayt_Dto.CommentDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebCoreUI.Controllers
{
    public class AdminCommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v = id;

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"http://localhost:5013/api/Comments/CommentListByBlog/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);

                if (values == null)
                {
                    var single = JsonConvert.DeserializeObject<ResultCommentDto>(jsonData);
                    return View(new List<ResultCommentDto> { single });
                }

                return View(values);
            }

            return View(new List<ResultCommentDto>());
        }
    }
}