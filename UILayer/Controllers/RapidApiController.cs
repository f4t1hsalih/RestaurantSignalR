using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UILayer.DTO.RapidApiDTO;

namespace UILayer.Controllers
{
    public class RapidApiController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=60&tags=under_30_minutes"),
                Headers =
    {
        { "x-rapidapi-key", "341c15bda0mshefa47b42aad83e6p1a5a46jsnb48a81a706cf" },
        { "x-rapidapi-host", "tasty.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultTastyApi>(body);
                return View(values);
            }
        }
    }
}
