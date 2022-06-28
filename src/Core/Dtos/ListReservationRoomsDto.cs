using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Dtos
{
    public class ListReservationRoomsDto
    {
        public ReservationDto reservation { get; set; }
        public List<ReservationRoomsDto> LReservationRoom { get; set; }
    }
}
