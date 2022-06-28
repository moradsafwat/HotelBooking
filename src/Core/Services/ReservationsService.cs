using HotelBooking.Core.Dtos;
using HotelBooking.Core.Repositories;
using HotelBooking.Core.Services;
using HotelBooking.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Services
{
    public class ReservationsService : IReservationsService
    {
        private readonly IReservationRepository _reservation;
        private readonly IRoomRepository _room;
        public ReservationsService(IReservationRepository reservation, IRoomRepository room)
        {
            _reservation = reservation;
            _room = room;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return (_reservation.List());
        }
        public ReservationDto GetById(int id)
        {
            var reservation = _reservation.Find(id);
            var dto = new ReservationDto
            {
                Id = reservation.Id,
                Name = reservation.Name,
                Email = reservation.Email,
                Phone =reservation.Phone,
                NumOfPeople = reservation.NumOfPeople,
                ArrivalDate =reservation.ArrivalDate,
                ArrivalTime =reservation.ArrivalTime,
                DepatureDate = reservation.DepatureDate,
                DepartureTime =reservation.DepatureDate
            };
            if (reservation != null)
                return dto;
            return null;
        }
        public ReservationDto Create(ReservationDto dto)
        {
            var reservation = new Reservation
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                ArrivalDate = dto.ArrivalDate,
                ArrivalTime = dto.ArrivalTime,
                DepatureDate = dto.DepatureDate,
                DepartureTime = dto.DepartureTime,
                NumOfPeople = dto.NumOfPeople
            };
            _reservation.Add(reservation);

            return dto;
        }

        public ReservationDto CreateReservationRooms(ReservationDto dto)
        {
            IList<Room> roomAdd = new List<Room>();
            var booking = new Reservation
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                ArrivalDate = dto.ArrivalDate,
                ArrivalTime = dto.ArrivalTime,
                DepatureDate = dto.DepatureDate,
                DepartureTime = dto.DepartureTime,
                NumOfPeople = dto.NumOfPeople,
            };
            foreach(var Rooms in dto.rooms)
            {
                var getRoom = _room.Find(Rooms.Id);
                if (getRoom != null)
                    roomAdd.Add(getRoom); 
            }
            booking.Rooms = roomAdd;
            _reservation.Add(booking);
            _room.SaveAsync();

            return dto;
        }
    }
}
