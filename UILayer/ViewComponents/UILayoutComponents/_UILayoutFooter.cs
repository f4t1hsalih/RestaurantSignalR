using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UILayer.DTO.ContactDTO;

namespace UILayer.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooter : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _UILayoutFooter(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7068/api/Contact");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var contacts = JsonConvert.DeserializeObject<List<ContactResultDTO>>(jsonData);
                return View(contacts);
            }
            return View();
        }
    }
}
