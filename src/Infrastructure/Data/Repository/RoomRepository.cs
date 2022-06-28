using HotelBooking.Core.Models;
using HotelBooking.Core.Repositories;
using HotelBooking.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Data.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(ApplicationDbContext _db) : base(_db)
        {
        }

        public IEnumerable<Room> GetRoomsByBranchId(int branchId)
        {
            var rooms = db.Rooms.Include(b => b.Branch )
                .Where(m => m.BranchId == branchId)
                .AsEnumerable()
                .GroupBy(x => x.RoomType)
                .Select(x => new Room
                {
                    Id = x.FirstOrDefault().Id,
                    RoomType = x.FirstOrDefault().RoomType,
                    BranchId = x.FirstOrDefault().BranchId,
                    Price = x.Min(i => i.Price)
                })
                .ToList();
            if (rooms == null)
                return null;

            return rooms;
        }
    }
}
