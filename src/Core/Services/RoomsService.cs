using HotelBooking.Core.Dtos;
using HotelBooking.Core.Models;
using HotelBooking.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Core.Services
{
    public class RoomsService : IRoomsService
    {
        private readonly IRoomRepository _room;
        public RoomsService(IRoomRepository room)
        {
            _room = room;
        }

        public IEnumerable<Room> GetAll()
        {
            return _room.List();
        }

        public IEnumerable<RoomDto> GetRoomsByBranchId(int branchId)
        {
            var rooms = _room.GetRoomsByBranchId(branchId).Select(r => new RoomDto
            {
                Id = r.Id,
                RoomName = r.RoomName,
                RoomType = r.RoomType,
                Price = r.Price,
                View = r.View,
                BranchId = r.BranchId,
            }); ;

            if (rooms != null)
                return rooms;
            return null;
        }
        public RoomDto GetById(int id)
        {
            var room = _room.Find(id);
            if (room != null)
            {
                var dto = new RoomDto
                {
                    Id = room.Id,
                    RoomName = room.RoomName,
                    RoomType = room.RoomType,
                    Price = room.Price,
                    View = room.View,
                    BranchId = room.BranchId,
                };
                return dto;
            }
            return null;
        }
        public RoomDto Add(RoomDto dto)
        {
            var room = new Room
            {
                RoomName = dto.RoomName,
                RoomType = dto.RoomType,
                Price = dto.Price,
                View = dto.View,
                BranchId = dto.BranchId
            };
            _room.Add(room);
            return dto;
        }

        public RoomDto Update(RoomDto dto)
        {
            var room = new Room
            {
                RoomName = dto.RoomName,
                RoomType = dto.RoomType,
                Price = dto.Price,
                View = dto.View,
                BranchId = dto.BranchId
            };
            _room.Update(room);
            return dto;
        }

        public RoomDto Delete(RoomDto dto)
        {
            var room = new Room
            {
                RoomName = dto.RoomName,
                RoomType = dto.RoomType,
                Price = dto.Price,
                View = dto.View,
                BranchId = dto.BranchId
            };
            _room.Remove(room);
            return dto;
        }

        public IEnumerable<RoomDto> GetAvaliableRoomsWithinDatesByBranch(int branchId, DateTime from, DateTime to)
        {
            var rooms = _room.GetAvaliableRoomsWithinDatesByBranch(branchId, from, to);
            if (rooms != null)
            { 
                return rooms
                .Select(x => new RoomDto
                {
                    Id = x.Id,
                    BranchId = x.BranchId,
                    Price = x.Price,
                    RoomName = x.RoomName,
                    RoomType = x.RoomType,
                    View = x.View,
                }).ToList();
            }
            else
            {
                return null;
            }

        }
    }
}
