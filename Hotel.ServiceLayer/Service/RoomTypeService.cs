using AutoMapper;
using Hotel.DataLayer.IRepositories;
using Hotel.ServiceLayer.IService;
using Hotel.ServiceLayer.ResponseModels;

namespace Hotel.ServiceLayer.Service;

public class RoomTypeService : IRoomTypeService
{
    private readonly IMapper _mapper;
    private readonly IRoomTypeRepository _roomTypeRepository;

    public RoomTypeService(IRoomTypeRepository roomTypeRepository, IMapper mapper)
    {
        _roomTypeRepository = roomTypeRepository;
        _mapper = mapper;
    }

    public async Task<List<RoomTypeResponseModel>> GetRoomTypes()
    {
        var roomTypes = await _roomTypeRepository.GetRoomTypes();
        var result = _mapper.Map<List<RoomTypeResponseModel>>(roomTypes);
        return result;
    }    
}
