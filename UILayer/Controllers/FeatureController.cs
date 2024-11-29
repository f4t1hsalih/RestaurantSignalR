using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UILayer.DTO.FeatureDTO;

namespace UILayer.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7068/api/Feature");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var features = JsonConvert.DeserializeObject<List<FeatureResultDTO>>(jsonData);
                return View(features);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7068/api/Feature/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var feature = JsonConvert.DeserializeObject<FeatureUpdateDTO>(jsonData);
                return View(feature);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(FeatureUpdateDTO feature)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(feature);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7068/api/Feature/", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
