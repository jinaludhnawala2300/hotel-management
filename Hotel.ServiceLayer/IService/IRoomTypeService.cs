using Hotel.ServiceLayer.ResponseModels;

namespace Hotel.ServiceLayer.IService;

public interface IRoomTypeService
{
    Task<List<RoomTypeResponseModel>> GetRoomTypes();
}
