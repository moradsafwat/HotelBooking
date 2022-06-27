using System.Collections.Generic;

namespace HotelBooking.WebApi.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
            Errors = new Dictionary<string, HashSet<string>>();
        }
        // Error Display message
        public string Message { get; set; }
        // Debugging message
        public string DetailedMessage { get; set; }
        public Dictionary<string, HashSet<string>> Errors { get; set; }
        public T Response { get; set; }
    }
}
