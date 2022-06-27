using HotelBooking.Core.Services;
using HotelBooking.Core.Dtos;
using HotelBooking.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationsService _reservations;

        public ReservationController(IReservationsService reservations)
        {
            _reservations = reservations;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_reservations.GetAll());
        }

    }   
}
