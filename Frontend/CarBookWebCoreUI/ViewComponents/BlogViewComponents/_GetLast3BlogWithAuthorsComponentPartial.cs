using CarBook_Ayt_Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.ViewComponents.BlogViewComponents
{
    public class _GetLast3BlogWithAuthorsComponentPartial : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _GetLast3BlogWithAuthorsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient("CarBookClient");
            var responseMessage = await client.GetAsync
                ("http://localhost:5013/api/Blog/GetLast3BlogsWithAuthorsQueryResult");
            if( responseMessage.IsSuccessStatusCode )
            { var jsondata= await responseMessage.Content.ReadAsStringAsync();
                var values = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<List<ResultGetLast3BlogsDto>>(jsondata);
                return View(values);
            }
            return View();
        }
    }
}
