using HotelBooking.Core.Dtos;
using HotelBooking.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Services
{
    public interface IReservationsService
    {
        IEnumerable<Reservation> GetAll();
        ReservationDto Create(ReservationDto dto);
        
        
        //ReservationDto GetById(int id);
        //ReservationDto Add(ReservationDto dto);
        //ReservationDto Delete(ReservationDto dto);
        //ReservationDto Update(ReservationDto dto);
    }
}
