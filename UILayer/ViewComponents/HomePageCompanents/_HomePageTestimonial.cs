using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UILayer.DTO.TestimonialDTO;

namespace UILayer.ViewComponents.HomePageCompanents
{
    public class _HomePageTestimonial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _HomePageTestimonial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7068/api/Testimonial");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var testimonials = JsonConvert.DeserializeObject<List<TestimonialResultDTO>>(jsonData);
                return View(testimonials);
            }
            return View();
        }
    }
}
