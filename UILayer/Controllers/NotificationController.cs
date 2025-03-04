﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UILayer.DTO.NotificationDTO;

namespace UILayer.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public NotificationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7068/api/Notification");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var notifications = JsonConvert.DeserializeObject<List<NotificationResultDTO>>(jsonData);
                return View(notifications);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateNotification()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotification(NotificationCreateDTO notification)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(notification);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7068/api/Notification", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7068/api/Notification/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var notification = JsonConvert.DeserializeObject<NotificationUpdateDTO>(jsonData);
                return View(notification);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateNotification(NotificationUpdateDTO notification)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(notification);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7068/api/Notification/", data);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteNotification(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7068/api/Notification/{id}");

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Bildirim başarıyla silindi.";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Bildirim silinirken bir hata oluştu.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatusToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:7068/api/Notification/ChangeStatusToTrue/{id}");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Bildirim başarıyla 'Görüldü' olarak güncellendi.";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Bildirim durumu güncellenirken bir hata oluştu.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatusToFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:7068/api/Notification/ChangeStatusToFalse/{id}");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Bildirim başarıyla 'Görülmedi' olarak güncellendi.";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Bildirim durumu güncellenirken bir hata oluştu.";
            return RedirectToAction("Index");
        }


    }
}
