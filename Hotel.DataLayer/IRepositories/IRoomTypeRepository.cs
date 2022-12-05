using Hotel.DataLayer.Entities;

namespace Hotel.DataLayer.IRepositories;

public interface IRoomTypeRepository
{
    Task<List<RoomType>> GetRoomTypes();

    Task<RoomType> GetRoomType(long id);
}
