using HotelBooking.Core.Models;
using HotelBooking.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Repositories
{
    public interface IReservationRepository : IRepository<Reservation>
    {
    }
}
