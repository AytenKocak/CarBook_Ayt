using CarBook_Ayt_Dto.FooterAdressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebCoreUI.ViewComponents.FooterAdressComponents
{
    public class _FooterAdressComponentPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterAdressComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
          var client=_httpClientFactory.CreateClient("CarBookClient");
            var responseMessage=await client.GetAsync("Contacts");
            if (!responseMessage.IsSuccessStatusCode)
            {
                return View("Index", new List<ResultFooterAdressDto>());
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFooterAdressDto>>(jsonData);

            return View(values);
        }
    }
}
