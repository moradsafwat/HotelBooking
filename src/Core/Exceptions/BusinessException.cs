using System;
using System.Globalization;

namespace HotelBooking.Core.Exceptions
{
    public class BusinessException: Exception
    {
        public BusinessException() : base() { }

        public BusinessException(string message) : base(message) { }

        public BusinessException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
