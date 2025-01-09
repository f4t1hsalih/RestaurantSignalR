using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UILayer.DTO.BasketDTO;
using UILayer.DTO.OrderDTO;
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
            // Masa ID kontrolü
            if (tableId == 0)
            {
                return BadRequest("Lütfen Bir Masa Seçiniz");
            }

            // DTO nesnesini oluştur
            BasketInsertDTO dto = new BasketInsertDTO
            {
                ProductId = productId,
                TableId = tableId
            };

            try
            {
                // HttpClient oluştur
                var client = _httpClientFactory.CreateClient();

                // Sepet işlemi
                var json = JsonConvert.SerializeObject(dto);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7068/api/Basket", data);

                // Sepet işlemi başarılıysa
                if (response.IsSuccessStatusCode)
                {
                    // Masa durumu güncelleme
                    var tableResponse = await client.GetAsync($"https://localhost:7068/api/Table/ChangeTableStatusToTrue/{tableId}");
                    if (!tableResponse.IsSuccessStatusCode)
                    {
                        return Json(new { success = false, message = "Masa durumu güncellenemedi." });
                    }

                    // Order tablosuna yeni kayıt ekleme
                    var orderDto = new OrderCreateDTO
                    {
                        TableId = tableId,
                        Description = "Müşteri Masada",
                        Date = DateTime.Now,
                        TotalPrice = 0, // Başlangıçta 0 olarak belirtiyoruz
                    };

                    var orderJson = JsonConvert.SerializeObject(orderDto);
                    var orderData = new StringContent(orderJson, Encoding.UTF8, "application/json");
                    var orderResponse = await client.PostAsync("https://localhost:7068/api/Order", orderData);

                    if (!orderResponse.IsSuccessStatusCode)
                    {
                        return Json(new { success = false, message = "Sipariş oluşturulurken bir hata oluştu." });
                    }

                    // İşlem başarılıysa yönlendirme
                    return RedirectToAction("Index");
                }

                // Sepet ekleme işlemi başarısızsa hata döndür
                var errorMessage = await response.Content.ReadAsStringAsync();
                return Json(new { success = false, message = errorMessage });
            }
            catch (Exception ex)
            {
                // Genel hata yönetimi
                return Json(new { success = false, message = $"Bir hata oluştu: {ex.Message}" });
            }
        }

    }
}
