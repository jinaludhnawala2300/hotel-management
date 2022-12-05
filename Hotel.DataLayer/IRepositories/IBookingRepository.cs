using Hotel.DataLayer.Entities;

namespace Hotel.DataLayer.IRepositories;

public interface IBookingRepository
{
    Task<int> BookRoom(Booking booking);

    Task<List<Booking>> GetBookings(long roomType);
}
