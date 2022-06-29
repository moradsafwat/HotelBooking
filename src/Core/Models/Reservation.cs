using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Core.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }
        
        [DataType(DataType.Time)]
        public DateTime ArrivalTime { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DepatureDate { get; set; }
       
        [DataType(DataType.Time)]
        public DateTime DepartureTime { get; set; }
        public string NumOfPeople { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
