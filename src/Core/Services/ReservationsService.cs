﻿using HotelBooking.Core.Dtos;
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
        public ReservationsService(IReservationRepository reservation)
        {
            _reservation = reservation;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return (_reservation.List());
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

        

        //public ReservationDto Add(ReservationDto dto)
        //{
        //    var reservation = new Reservation
        //    {
        //        Id = dto.Id,
        //        Name = dto.Name,
        //        Email = dto.Email,
        //        Phone = dto.Phone,
        //        ArrivalDate = dto.ArrivalDate,
        //        ArrivalTime = dto.ArrivalTime,
        //        DepatureDate = dto.DepatureDate,
        //        DepartureTime = dto.DepartureTime,
        //        NumOfPeople = dto.NumOfPeople
        //    };
        //    _reservation.Add(reservation);

        //    return dto;
        //}

    }
}
