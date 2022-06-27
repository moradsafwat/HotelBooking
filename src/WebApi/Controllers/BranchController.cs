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
    public class BranchController : ControllerBase
    {
        private readonly IBranchsService _branchsService;
        private readonly IHotelsService _hotelsService;
        public BranchController(IBranchsService branchsService, IHotelsService hotelsService)
        {
            _branchsService = branchsService;
            _hotelsService = hotelsService;
        }
      
        [HttpGet("GetAll")]
        public IActionResult GetAllBanchs()
        {
            var branchs = _branchsService.GetWithHotel().Select( b => new BranchDto 
            {
                Id = b.Id,
                BranchName = b.BranchName,
                Location = b.Location,
                HotelId = b.HotelId,
                HotelName = b.Hotel.HotelName
            });
            return Ok(branchs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var branch = _branchsService.GetById(id);
            if(branch == null)
                return NotFound($"Sorry .. Not Found Branch With ID : {id}");
            return Ok(branch);
        }
        //[HttpGet("GetByIdWithRoom")]
        //public IActionResult GetByIdWithRoom(int id)
        //{
        //    var branch = _branchsService.GetById(id);
        //    if (branch == null)
        //        return NotFound($"Sorry .. Not Found Branch With ID : {id}");
        //    return Ok(branch);
        //}
        [HttpPost]
        public IActionResult CreateBranch(BranchDto dto)
        {
            var branch = new Branch
            {
                BranchName = dto.BranchName,
                Location = dto.Location,
                HotelId = dto.HotelId
            };
            var check = _hotelsService.GetById(dto.HotelId);
            if (check == null)
                return NotFound($"Sorry .. Not Found Hotel With ID : {dto.HotelId}");

            _branchsService.Add(dto);   
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBranch(int id, [FromBody] BranchDto branchDto)
        {
            var branch = _branchsService.GetById(id);
            if (branch == null)
                return NotFound($"Not Found Branch With ID : {id}");

            var check = _hotelsService.GetById(branchDto.HotelId);
            if (check == null)
                return NotFound($"Sorry .. Not Found Hotel With ID : {branchDto.HotelId}");
            
            branch.Id = branchDto.Id;
            branch.BranchName = branchDto.BranchName;
            branch.Location = branchDto.Location;
            branch.HotelId = branchDto.HotelId;

            _branchsService.Update(branchDto);
            _branchsService.SaveChange();
            //_branchsService.Update(dto);
            return Ok(branchDto);
        }
        [HttpDelete]
        public IActionResult DeleteBranch(int id)
        {
            var branch = _branchsService.GetById(id);
            if (branch == null)
                return NotFound($"Not Found Branch With ID : {id}");
            _branchsService.Delete(branch);
            return Ok(branch);
        }
    }
}
