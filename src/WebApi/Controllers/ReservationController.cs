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
        private readonly IRoomsService _rooms;

        public ReservationController(IReservationsService reservations, IRoomsService rooms)
        {
            _reservations = reservations;
            _rooms = rooms;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_reservations.GetAll());
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var reservation = _reservations.GetById(id);
            if (reservation == null)
                return NotFound($"Sorry ... Not Found Reservation With ID : {id}");

            return Ok(reservation);
        }

        [HttpPost("CreateReservation")]
        public IActionResult CreateReservation([FromBody]ReservationDto dto)
        {
            //var check = _reservations.GetById(dto.BranchId);
            if (dto == null)
                return NotFound($"Sorry .. NotFound Reservation To Create");

            _reservations.Create(dto);
            return Ok(dto);
        }
        [HttpPost("CreateReservationRooms")]
        public IActionResult CreateReservationRoos(ReservationDto dto)
        {
            if (dto == null)
                return NotFound($"Sorry .. NotFound Reservation To Create");

            _reservations.CreateReservationRooms(dto);
            return Ok(dto);
        }

    }   
}
