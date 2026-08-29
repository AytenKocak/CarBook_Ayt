using CarBook_Ayt_Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBookWebCoreUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardBlogListComponentPartial : ViewComponent        

    { private readonly IHttpClientFactory _httpclientfactory;

        public _AdminDashboardBlogListComponentPartial(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory = httpclientfactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpclientfactory.CreateClient();

            var response = await client.GetAsync("http://localhost:5013/api/Blogs/GetAllBlogsWithAuthorList");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
                return View(values);
            }
            return View();
        }


    }
}
