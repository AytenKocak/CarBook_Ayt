using CarBook_Ayt_Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsAuthorAboutComponentPartial:ViewComponent
    {  private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsAuthorAboutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.blogid = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5013/api/Blog/GetBlogByAuthorId?id="+id);
            if(responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultGetAuthorByBlogAuthorIdDto>>(jsonData);
                    return View(values);
            }
            return View();
        } 
    }
}
