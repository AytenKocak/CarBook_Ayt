using CarBook_Ayt_Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBookWebCoreUI.ViewComponents.ServiceViewComponents
{
    public class _ServiceComponentPartial:ViewComponent
    {
        public readonly IHttpClientFactory _httpClientFactory;

        public _ServiceComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient("CarBookClient");
            var responseMessage = await client.GetAsync("Services");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content
                    .ReadFromJsonAsync<List<ResultServiceDto>>()
                    ?? new List<ResultServiceDto>();

                return View(jsonData);
            }

            return View(new List<ResultServiceDto>());
        }
    }
}
