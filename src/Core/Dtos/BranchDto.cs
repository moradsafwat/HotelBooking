using HotelBooking.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Core.Dtos
{
    public class BranchDto
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string Location { get; set; }
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public RoomTypeEnum RoomType { get; set; }
        public double Price { get; set; }

    }
}
