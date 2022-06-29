using HotelBooking.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Core.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        IEnumerable<Room> GetRoomsByBranchId(int branchId);
        IEnumerable<Room> GetAvaliableRoomsWithinDatesByBranch(int branchId, DateTime from, DateTime to);

    }
}
