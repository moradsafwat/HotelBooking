using HotelBooking.Core.Configuration;
using HotelBookig.Core.Repositories;
using HotelBooking.Infrastructure.Data.Repository;
using HotelBooking.Core.Mapping;
using HotelBooking.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HotelBooking.Core.Repositories;
using HotelBooking.Infrastructure.Data.Repositories;
using HotelBooking.Core.Services;

namespace HotelBooking.WebApi.Configuration
{
    public static class CoreServicesConfiguration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<JwtConfiguration>(configuration.GetSection(JwtConfiguration.JwtConfigurations));
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            // START REPOS
            //services.addscoped(typeof(Irepository<>), typeof(repository<>));
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            // END REPOS

            // START SERVICES
            //services.AddScoped(typeof(IBranchsService<>), typeof(BranchsService<>));
            services.AddScoped<IHotelsService, HotelsService>();
            services.AddScoped<IBranchsService, BranchsService>();
            services.AddScoped<IRoomsService, RoomsService>();
            services.AddScoped<IReservationsService, ReservationsService>();
            //// END SERVICES

            return services;
        }
    }
}
