using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UILayer.DTO.SliderDTO;

namespace UILayer.Controllers
{
    public class SliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7068/api/Slider");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var sliders = JsonConvert.DeserializeObject<List<SliderResultDTO>>(jsonData);
                return View(sliders);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSlider(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7068/api/Slider/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var slider = JsonConvert.DeserializeObject<SliderUpdateDTO>(jsonData);
                return View(slider);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSlider(SliderUpdateDTO slider)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(slider);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7068/api/Slider/", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
