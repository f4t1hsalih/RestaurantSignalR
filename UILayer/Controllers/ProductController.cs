using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using UILayer.DTO.CategoryDTO;
using UILayer.DTO.ProductDTO;

namespace UILayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7068/api/Product/ProductWithCategories");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ProductResultDTO>>(jsonData);
                return View(products);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7068/api/Category");
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CategoryResultDTO>>(json);
            List<SelectListItem> categoryNames = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();
            ViewBag.CategoryNames = categoryNames;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreateDTO product)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(product);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7068/api/Product", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7068/api/Product/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseForCategory = await client.GetAsync("https://localhost:7068/api/Category");
            var jsonForCategory = await responseForCategory.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CategoryResultDTO>>(jsonForCategory);
            List<SelectListItem> categoryNames = (from x in values
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Name,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.CategoryNames = categoryNames;

            var response = await client.GetAsync($"https://localhost:7068/api/Product/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<ProductUpdateDTO>(jsonData);
                return View(product);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDTO product)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(product);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7068/api/Product/", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
