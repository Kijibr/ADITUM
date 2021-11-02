using ADITUM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ADITUM.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private static List<Restaurant> rest = new List<Restaurant>();

        const string BASE_URL = "https://retoolapi.dev/EhQgZs/";

        public IEnumerable<Restaurant> Restaurants { get; set;}

        public RestaurantController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var message = new HttpRequestMessage();
            message.Method = HttpMethod.Get;
            message.RequestUri = new Uri($"{BASE_URL}/aditum");
            message.Headers.Add("Accept", "application/json");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(message);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                Restaurants = await JsonSerializer.DeserializeAsync<IEnumerable<Restaurant>>(responseStream);
            } else
            {
                Restaurants = Array.Empty<Restaurant>();
            }

            return View(Restaurants);  
        }
    }
}
