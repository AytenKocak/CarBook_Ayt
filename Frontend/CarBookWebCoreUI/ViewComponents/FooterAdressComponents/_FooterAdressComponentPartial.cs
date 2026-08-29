using CarBook_Ayt_Dto.FooterAdressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebCoreUI.ViewComponents.FooterAddressComponents
{
    public class _FooterAddressComponentPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterAddressComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
          var client=_httpClientFactory.CreateClient("CarBookClient");
            var responseMessage=await client.GetAsync("Contacts");
            if (!responseMessage.IsSuccessStatusCode)
            {
                return View("Default", new List<ResultFooterAddressDto>());
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsonData);

            return View(values);
        }
    }
}
