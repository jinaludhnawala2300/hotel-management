using AutoMapper;
using Hotel.DataLayer.Entities;
using Hotel.DataLayer.IRepositories;
using Hotel.ServiceLayer.Exceptions;
using Hotel.ServiceLayer.RequestModels;
using Hotel.ServiceLayer.ResponseModels;
using Hotel.ServiceLayer.Service;
using Moq;

namespace Hotel.ServiceLayer.Test;

public class RoomTypeServiceTest
{
    Mock<IRoomTypeRepository> roomTypeRepository;
    Mock<IMapper> mapper;
    RoomTypeService roomTypeService;

    public RoomTypeServiceTest()
    {        
        this.roomTypeRepository = new Mock<IRoomTypeRepository>();        
        this.mapper = new Mock<IMapper>();
        this.roomTypeService = new RoomTypeService(roomTypeRepository.Object, mapper.Object);
    }

    [Fact]
    public async Task GetRoomTypes()
    {       
        var roomTypeResponse = new List<RoomTypeResponseModel>();
        roomTypeResponse.Add(new RoomTypeResponseModel()
        {
            Name = "SingleRoom"
        });
        roomTypeRepository.Setup(repo => repo.GetRoomTypes()).ReturnsAsync(new List<RoomType>());
        mapper.Setup(x => x.Map<List<RoomTypeResponseModel>>(It.IsAny<List<RoomType>>()))
                .Returns(roomTypeResponse);

        var result = await roomTypeService.GetRoomTypes();
        Assert.True(result.Count() == 1);
    }

    
}
