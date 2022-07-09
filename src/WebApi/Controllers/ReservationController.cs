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
        [HttpGet("GetAllReservation")]
        public IActionResult GetAllReservation()
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
        [HttpGet("GetAllReservationWithRooms")]
        public IActionResult GetAllReservationWithRooms(int reservationid)
        {
            var reservation = _reservations.GetReservationRooms(reservationid);
            if (reservation == null)
                return NotFound($"Sorry ... Not Found Reservation With ID : {reservationid}");

            return Ok(reservation);
        }
        //[HttpPost("CreateReservation")]
        //public IActionResult CreateReservation([FromBody]ReservationDto dto)
        //{
        //    //var check = _reservations.GetById(dto.BranchId);
        //    if (dto == null)
        //        return NotFound($"Sorry .. NotFound Reservation To Create");

        //    _reservations.Create(dto);
        //    return Ok(dto);
        //}
        [HttpPost("CreateReservationWithRooms")]
        public IActionResult CreateReservationWithRooms(ReservationDto dto)
        {
            if (dto == null)
                return NotFound($"Sorry .. NotFound Reservation To Create");

            _reservations.CreateReservationRooms(dto);
            return Ok(dto);
        }
        [HttpDelete("DeleteReservation")]
        public IActionResult DeleteReservation(int id)
        {
            var reservation = _reservations.GetById(id);
            if (reservation == null)
                return NotFound($"Sorry ... Not Found Reservation With ID : {id}");

            _reservations.Delete(reservation);
            return Ok(reservation);
        }
    }   
}
