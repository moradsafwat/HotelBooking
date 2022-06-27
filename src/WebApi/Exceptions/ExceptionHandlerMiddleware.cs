using HotelBooking.Core.Exceptions;
using HotelBooking.WebApi.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelBooking.WebApi.Exceptions
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var apiResponse = new ApiResponse<string>();
                switch (error)
                {
                    case BusinessException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        apiResponse.Message = e.Message;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        apiResponse.DetailedMessage = error.Message;
                        break;
                }

                var result = JsonSerializer.Serialize(apiResponse, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });
                await response.WriteAsync(result);
            }
        }
    }
}
