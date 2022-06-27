using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Core.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string Location { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
