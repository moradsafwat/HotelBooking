using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Core.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string HotelName { get; set; }

        public List<Branch> Branches { get; set; }
    }
}
