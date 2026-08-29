using CarBook_Ayt_Dto.CommentDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebCoreUI.ViewComponents.CommentsViewComponets
{
    public class CommentsListByBlogComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentsListByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
          
            ViewBag.blogid = id;

            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync(
        $"http://localhost:5013/api/Comments/CommentListByBlog/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);

                return View(values);
            }

            return View(new List<ResultCommentDto>());
        }
    }
}