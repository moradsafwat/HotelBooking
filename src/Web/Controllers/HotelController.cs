using HotelBooking.Core.Dtos;
using HotelBooking.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HotelBooking.Web.Controllers
{
    public class HotelController : Controller
    {
        string baseUrl = "https://localhost:44391/";
        public async Task<IActionResult> Index()
        {
            IEnumerable<HotelDto> hotelDtoView = null;
            HttpClient client = new HttpClient();
            
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/Hotel/GetAllHotel");

            if (response.IsSuccessStatusCode)
            {
                string hotelRes = await response.Content.ReadAsStringAsync();

               hotelDtoView = JsonConvert.DeserializeObject<IEnumerable<HotelDto>>(hotelRes);
            }
           
            return View(hotelDtoView);
        }
    }
}
