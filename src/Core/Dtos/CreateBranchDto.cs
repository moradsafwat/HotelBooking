
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Core.Dtos
{
    public class CreateBranchDto
    {
        public string BranchName { get; set; }
        public string Location { get; set; }

        public int HotelId { get; set; }
    }
}
