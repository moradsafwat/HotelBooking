using HotelBooking.Core.Interfaces.Repositories;
using HotelBooking.Core.Models;
using HotelBooking.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Data.Repository
{
    public class ReservationRoomRepository : Repository<ReservationRoom>, IReservationRoomRepository
    {
        public ReservationRoomRepository(ApplicationDbContext _db) : base(_db)
        {
        }
    }
}
