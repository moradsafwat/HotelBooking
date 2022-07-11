using HotelBooking.Core.Dtos;
using HotelBooking.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HotelBooking.Web.Controllers
{
    public class ReservationController : Controller
    {
        string baseUrl = "https://localhost:44391/api/";
        HttpClient client = new HttpClient();

        public IActionResult CreateReservation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReservation(Reservation reserv)
        {
            var booking = new ReservationDto
            {
                Name = reserv.Name,
                Email = reserv.Email,
                Phone = reserv.Phone,
                ArrivalDate = reserv.ArrivalDate,
                ArrivalTime = reserv.ArrivalTime,
                DepatureDate = reserv.DepatureDate,
                DepartureTime = reserv.DepartureTime,
                NumOfPeople = reserv.NumOfPeople
            };
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage res = await client.PostAsJsonAsync<ReservationDto>("Reservation/CreateReservationWithRooms", booking);

            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");

            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(booking);
        }
    }
}
