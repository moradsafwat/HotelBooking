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
        ReservationDto GetById(int id);
        ReservationDto Create(ReservationDto dto);
        ReservationDto CreateReservationRooms(ReservationDto dto);
        //ReservationDto Add(ReservationDto dto);
        //ReservationDto Delete(ReservationDto dto);
        //ReservationDto Update(ReservationDto dto);
    }
}
