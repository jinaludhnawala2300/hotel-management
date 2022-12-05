using Hotel.DataLayer.Entities;
using Hotel.DataLayer.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DataLayer.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly HotelContext _context;
        public RoomTypeRepository(HotelContext context)
        {
            _context = context;
        }

        public async Task<List<RoomType>> GetRoomTypes()
        {
            var roomTypes = await _context.RoomType.ToListAsync();
            if (roomTypes == null)
                return null;

            return roomTypes;
        }

        public async Task<RoomType> GetRoomType(long id)
        {
            return  _context.RoomType.FirstOrDefault(rt => rt.Id == id);
        }
    }
}
