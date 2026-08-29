using CarBook_Ayt_Dto.DescriptionDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBookWebCoreUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCarDescriptionByCarIdComponenetPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailCarDescriptionByCarIdComponenetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.carid = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5013/api/CarDescribtions?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultDescriptionByCarIdDto>(jsondata);
                return View(values);
            }


            return View(new ResultDescriptionByCarIdDto());

        }
    }
}
