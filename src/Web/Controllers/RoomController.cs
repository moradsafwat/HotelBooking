using HotelBooking.Core.Dtos;
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
    public class RoomController : Controller
    {
        readonly string baseUrl = "https://localhost:44391/api/";
        HttpClient client = new HttpClient();


        public IActionResult RoomAvailable()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> RoomAvailable(int Id, DateTime? from, DateTime? to)
        {
            int branchId = Id;
            IEnumerable<RoomDto> roomDto = null;
            if (from != null && to != null)
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync($"Room/GetAvaliableRoomsWithinDatesByBranch?branchId={branchId}&from={from}&to={to}");

                if (res.IsSuccessStatusCode)
                {
                    string roomRes = await res.Content.ReadAsStringAsync();
                    roomDto = JsonConvert.DeserializeObject<IEnumerable<RoomDto>>(roomRes);

                    return View(roomDto);
                }
            }
            return View();
        }
    }
}
