using Hotel.DataLayer.Entities;
using Hotel.DataLayer.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DataLayer.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelContext _context;
        public BookingRepository(HotelContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetBookings(long roomTypeId)
        {
            return await _context.Booking.Where(x => x.RoomTypeId == roomTypeId).ToListAsync();
        }

        public async Task<int> BookRoom(Booking booking)
        {
            await _context.Booking.AddAsync(booking);
            return await _context.SaveChangesAsync();
        }
    }
}
