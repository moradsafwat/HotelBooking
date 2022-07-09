using HotelBooking.Core.Dtos;
using HotelBooking.Core.Services;
using HotelBooking.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace HotelBooking.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelsService _hotelsService;
        //private readonly ILogger  _logger;

        public HotelController(/*ILogger logger,*/  IHotelsService hotelsService)
        {
            //_logger = logger;
            _hotelsService = hotelsService;
        }

        [HttpGet("GetAllHotel")]
        public IActionResult GetAllHotel()
        {
            return Ok(_hotelsService.GetAll());
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var hotel = _hotelsService.GetById(id);
            if (hotel == null)
                return NotFound($"Not Found This ID : {id}");
            
            return Ok(hotel);
        }

        [HttpPost("CreateHotel")]
        public IActionResult CreateHotel(HotelDto dto)
        {
            _hotelsService.Add(dto);
            return Ok(dto);
        }

        [HttpPut("UpdateHotel")]
        public IActionResult UpdateHotel(int id, HotelDto dto)
        {
            var hotel = _hotelsService.GetById(id);
            if (hotel == null)
                return NotFound($"Sorry ... Not Found Hotel ID : {id}");

            _hotelsService.Update(dto);
            return Ok();
        }

        [HttpDelete("DeleteHotel")]
        public IActionResult DeleteHotel(int id)
        {
            var hotel = _hotelsService.GetById(id);
            if(hotel == null)
                return NotFound($"Not Found Hotel ID : {id}");

            _hotelsService.Delete(hotel);            
            return Ok(hotel);
        }
    }
}
