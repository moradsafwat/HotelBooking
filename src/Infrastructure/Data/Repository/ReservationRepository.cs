using HotelBooking.Core.Models;
using HotelBooking.Core.Repositories;
using HotelBooking.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Data.Repository
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ApplicationDbContext _db) : base(_db)
        {
        }
    }
}
