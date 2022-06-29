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
        IEnumerable<ReservationRoomsDto> GetReservationRooms(int reservationId);

        ReservationDto Create(ReservationDto dto);
        ReservationDto CreateReservationRooms(ReservationDto dto);
        ReservationDto Delete(ReservationDto dto);
        //ReservationDto Update(ReservationDto dto);
    }
}
