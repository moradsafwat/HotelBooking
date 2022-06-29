using HotelBooking.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Core.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public RoomTypeEnum RoomType { get; set; }
        public string View { get; set; }
        public double Price { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
    }
}
