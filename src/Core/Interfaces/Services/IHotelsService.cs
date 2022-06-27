using HotelBooking.Core.Dtos;
using HotelBooking.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Core.Services
{
    public interface IHotelsService
    {
        IEnumerable<Hotel> GetAll();
        HotelDto GetById(int id);
        HotelDto Add(HotelDto hotelDto);
        HotelDto Delete(HotelDto hotelDto);
        HotelDto Update(HotelDto hotelDto);
    }
}
