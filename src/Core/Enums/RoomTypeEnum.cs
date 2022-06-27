using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelBooking.Core.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RoomTypeEnum
    {
        Single = 1,
        Double,
        Suite
    }
}
