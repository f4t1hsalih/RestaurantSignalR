using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UILayer.DTO.BasketDTO;

namespace UILayer.Controllers
{
    [AllowAnonymous]
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            //Masa numarasını viewbag'e ekle
            ViewBag.TableId = id;

            //Bir masa numarası seçilmediyse anasayfaya yönlendir ve uyarı ver
            if (id == 0)
            {
                TempData["Message"] = "Lütfen bir masa numarası seçiniz!";
                return RedirectToAction("Index", "Home");
            }

            //Sepet bilgilerini getir
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7068/api/Basket/GetBasketByTableNumberWithProductNames/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var basket = JsonConvert.DeserializeObject<List<BasketResultWithProductNamesDto>>(jsonData);
                return View(basket);
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id, int tableId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7068/api/Basket/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", new { id = tableId });
            }
            return NoContent();
        }

    }
}
