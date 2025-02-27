﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UILayer.DTO.BookingDTO;

namespace UILayer.Controllers
{
    [AllowAnonymous]
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(BookingCreateDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            System.Diagnostics.Debug.WriteLine("Gönderilen JSON: " + json); // JSON çıktısını kontrol edin
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7068/api/Booking", data);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index", "Home");

            var errorContent = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, errorContent);
            return View();
        }
    }
}
