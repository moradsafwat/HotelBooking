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
            //var rooms = db.Rooms.Include(i => i.Branch)
            //   .GroupBy(x => x.RoomType)
            //   .Select(g => g.OrderBy(x => x.Price)
            //   .FirstOrDefault());

            var rooms = db.Rooms.Where(m => m.BranchId == branchId)
                .Select(x => new Room
                {
                    Id = x.Id,
                    RoomType = x.RoomType,
                    BranchId = x.BranchId,

                    x => x.Min(i => i.Price)
                }).GroupBy(x => x.RoomType).ToList();


            return rooms;
        }
    }
}
