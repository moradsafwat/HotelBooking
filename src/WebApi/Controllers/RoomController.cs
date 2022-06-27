using HotelBooking.Core.Dtos;
using HotelBooking.Core.Models;
using HotelBooking.Core.Services;
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
    public class RoomController : ControllerBase
    {
        private readonly IRoomsService _roomsService;
        private readonly IBranchsService _branchsService;

        public RoomController(IRoomsService roomsService, IBranchsService branchsService)
        {
            _roomsService = roomsService;
            _branchsService = branchsService;
        }

        [HttpGet("GetAllRoom")]
        public IActionResult GetAllRoom(int branchId)
        {
            var room = _roomsService.GetRoomsByBranchId(branchId).Select(r => new RoomDto
            {
                RoomId = r.Id,
                RoomName = r.RoomName,
                RoomType = r.RoomType,
                Price = r.Price,
                View = r.View,
                BranchId = r.BranchId ,
                BranchName = r.Branch.BranchName
            });
            return Ok(room);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var room = _roomsService.GetById(id);
            if (room == null)
                return NotFound($"Not Found This ID : {id}");

            return Ok(room);
        }
        [HttpGet("GetRoomsByBranchId")]
        public IActionResult GetRoomsByBranchId(int branchId)
        {
            var rooms = _roomsService.GetRoomsByBranchId(branchId).Select(r => new RoomDto
            {
                RoomId = r.Id,
                RoomName = r.RoomName,
                RoomType = r.RoomType,
                Price = r.Price,
                View = r.View,
                BranchId = r.BranchId,
                BranchName = r.Branch.BranchName
            });
            if (rooms != null)
                return Ok(rooms);

            return NotFound($"Not Found This ID : {branchId}");
        }
        [HttpPost]
        public IActionResult CreateRoom(RoomDto dto)
        {
            var room = new Room
            {
                RoomName = dto.RoomName,
                RoomType = dto.RoomType,
                Price =dto.Price,
                View =dto.View ,
                BranchId = dto.BranchId 
            };
            var check = _branchsService.GetById(dto.BranchId);
            if (check == null)
                return NotFound($"Sorry .. Not Found Branch With ID : {dto.BranchId}");

            _roomsService.Add(dto);
            return Ok(dto);
        }
        [HttpDelete]
        public IActionResult DeleteRoom(int id)
        {
            var room = _roomsService.GetById(id);
            if (room == null)
                return NotFound($"Not Found This ID : {id}");

            _roomsService.Delete(room);
            return Ok(room);
        }


    }
}
