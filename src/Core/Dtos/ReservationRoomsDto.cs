using HotelBooking.Core.Enums;
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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }

        public DateTime ArrivalDate { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DateTime DepatureDate { get; set; }

        public DateTime DepartureTime { get; set; }
        public string NumOfPeople { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public RoomTypeEnum RoomType { get; set; }
        public string View { get; set; }
        public double Price { get; set; }
    }
}
