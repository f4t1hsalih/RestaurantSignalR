using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UILayer.DTO.BasketDTO;
using UILayer.DTO.ProductDTO;

namespace UILayer.Controllers
{
    [AllowAnonymous]
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Eğer menüye giriş yapılırken masa id'si ile giriş yapılacaksa bu şekilde bir route tanımlaması yapılabilir, ama menüyü görmek için giriş yapılmasına gerek yoksa bu şekilde bir route tanımlaması yapılmasına gerek yoktur. Bu yüzden program.cs dosyasındaki orjinal route tanımlamasını kullandık böylece id gelirse eğer viewbag ile view'e taşıyabiliriz ve gelmez ise id 0 olacak ve bu şekilde bir işlem yapmamıza gerek kalmayacaktır.
        //[Route("Menu/Index/{tableId:int}")]
        public async Task<IActionResult> Index(int id)
        {
            //Bu kısımda masa id'sini viewbag ile view'e taşıdık
            ViewBag.tableId = id;

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7068/api/Product/ProductWithCategories");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var foods = JsonConvert.DeserializeObject<List<ProductResultDTO>>(jsonData);
                return View(foods);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket(int productId, int tableId)
        {
            if (tableId == 0)
            {
                return BadRequest("Lütfen Bir Masa Seçiniz");
            }

            BasketInsertDTO dto = new BasketInsertDTO
            {
                ProductId = productId,
                TableId = tableId
            };

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7068/api/Basket", data);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Hata mesajını döndürüyoruz
                var errorMessage = await response.Content.ReadAsStringAsync();
                return Json(new { success = false, message = errorMessage });
            }
        }


    }
}
