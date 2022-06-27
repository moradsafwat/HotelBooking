using HotelBooking.Core.Dtos;
using HotelBooking.Core.Models;
using HotelBooking.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Core.Services
{
    public class HotelsService : IHotelsService
    {
        private readonly IHotelRepository _hotel;
        public HotelsService(IHotelRepository hotel)
        {
            _hotel = hotel;
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _hotel.List();
        }
        public HotelDto GetById(int id)
        {
            var hotel = _hotel.Find(id);
            if (hotel != null)
            {
                var dto = new HotelDto
                {
                    HotelId = hotel.Id,
                    HotelName = hotel.HotelName
                };
                return dto;
            }
            return null;
        }
        public HotelDto Add(HotelDto dto)
        {
            var hotel = new Hotel
            {
                HotelName = dto.HotelName
            };

            _hotel.Add(hotel);
            return dto;
        }
        public HotelDto Update(HotelDto dto)
        {
            var hotel = new Hotel
            {
                HotelName = dto.HotelName
            };

            _hotel.Update(hotel);
            return dto;
        }
        public HotelDto Delete(HotelDto dto)
        {
            var hotel = new Hotel
            {
                HotelName = dto.HotelName
            };

            _hotel.Remove(hotel);
            return dto;
        }
    }
}
