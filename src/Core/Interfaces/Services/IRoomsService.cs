using HotelBooking.Core.Dtos;
using HotelBooking.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Core.Services
{
    public interface IRoomsService
    {
        IEnumerable<Room> GetAll();
        IEnumerable<RoomDto> GetRoomsByBranchId(int branchId);
        RoomDto GetById(int id);
        RoomDto Add(RoomDto roomDto);
        RoomDto Delete(RoomDto roomDto);
        RoomDto Update(RoomDto roomDto);
        IEnumerable<RoomDto> GetAvaliableRoomsWithinDatesByBranch(int branchId, DateTime from, DateTime to);

    }
}
