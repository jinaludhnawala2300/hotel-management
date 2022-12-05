using Hotel.DataLayer.IRepositories;
using Hotel.DataLayer.Repositories;
using Hotel.ServiceLayer.IService;
using Hotel.ServiceLayer.Service;

namespace Hotel.Configurations;

public static class DependencyConfiguration
{
    public static void AddDependency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IRoomTypeService, RoomTypeService>();
        services.AddTransient<IRoomTypeRepository, RoomTypeRepository>();
        services.AddTransient<IBookingRepository, BookingRepository>();
        services.AddTransient<IBookingService, BookingService>();
        services.AddTransient<IContactRepository, ContactRepository>();
        services.AddTransient<IContactService, ContactService>();
        services.AddAutoMapper(typeof(AutoMapperProfile));
    }
}
