using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UILayer.DTO.TableDTO;

namespace UILayer.Controllers
{
    public class TableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7068/api/Table");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<TableResultDTO>>(jsonData);
                return View(categories);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateTable()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTable(TableCreateDTO table)
        {
            table.Status = false;
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(table);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7068/api/Table", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteTable(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7068/api/Table/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTable(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7068/api/Table/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var table = JsonConvert.DeserializeObject<TableUpdateDTO>(jsonData);
                return View(table);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTable(TableUpdateDTO table)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(table);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7068/api/Table/", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
