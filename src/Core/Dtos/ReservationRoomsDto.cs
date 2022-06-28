using HotelBooking.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Dtos
{
    public class ReservationRoomsDto
    {
        public ReservationDto reservation { get; set; }
        public List<int> roomIds { get; set; }
    }
}
