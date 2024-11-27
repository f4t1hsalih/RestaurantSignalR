using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UILayer.DTO.CategoryDTO;

namespace UILayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7068/api/Category");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<CategoryResultDTO>>(jsonData);
                return View(categories);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryCreateDTO category)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(category);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7068/api/Category", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7068/api/Category/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7068/api/Category/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var category = JsonConvert.DeserializeObject<CategoryUpdateDTO>(jsonData);
                return View(category);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateDTO category)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(category);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7068/api/Category/", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
