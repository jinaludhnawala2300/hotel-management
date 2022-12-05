using AutoMapper;
using Hotel.DataLayer.Entities;
using Hotel.DataLayer.IRepositories;
using Hotel.ServiceLayer.Exceptions;
using Hotel.ServiceLayer.RequestModels;
using Hotel.ServiceLayer.ResponseModels;
using Hotel.ServiceLayer.Service;
using Moq;

namespace Hotel.ServiceLayer.Test;

public class BookingServiceTest
{
    Mock<IBookingRepository> bookingRepository;
    Mock<IRoomTypeRepository> roomTypeRepository;
    Mock<IMapper> mapper;
    BookingService bookingService;

    public BookingServiceTest()
    {        
        this.bookingRepository = new Mock<IBookingRepository>();        
        this.roomTypeRepository = new Mock<IRoomTypeRepository>();
        this.mapper = new Mock<IMapper>();
        this.bookingService = new BookingService(bookingRepository.Object, roomTypeRepository.Object, mapper.Object);
    }

    [Fact]
    public async Task BookRoom()
    {
        var roomType = new RoomType();
        roomType.Price = 800;
        roomType.ServiceCharges = 10.2M;
        var booking = new Booking(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<long>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>(), It.IsAny<decimal>());
        var bookingRequestModel = new BookingRequestModel();
        bookingRequestModel.CustomerContactNo = 1234567892;
        bookingRequestModel.CustomerEmailId = "bigscal.@com";
        bookingRequestModel.CheckInDate = Convert.ToDateTime("2022/12/05");
        bookingRequestModel.CheckOutDate = Convert.ToDateTime("2022/12/06");

        roomTypeRepository.Setup(repo => repo.GetRoomType(It.IsAny<long>())).ReturnsAsync(roomType);        
        bookingRepository.Setup(repo => repo.BookRoom(It.IsAny<Booking>())).ReturnsAsync(1).Callback(() => booking.Id = 1);
        mapper.Setup(x => x.Map<BookingResponseModel>(It.IsAny<Booking>()))
                .Returns(new BookingResponseModel());

        var result = await bookingService.BookRoomAsync(bookingRequestModel);
        Assert.True(booking.Id == 1);
    }

    [Fact]
    public async Task BookRoom_MustFail()
    {
        var roomType = new RoomType();
        roomType.Price = 800;
        roomType.ServiceCharges = 10.2M;
        var bookingRequestModel = new BookingRequestModel();
        bookingRequestModel.CustomerContactNo = 1234567892;
        bookingRequestModel.CustomerEmailId = "bigscal.@com";
        bookingRequestModel.CheckInDate = Convert.ToDateTime("2022/12/05");
        bookingRequestModel.CheckOutDate = Convert.ToDateTime("2022/12/06");

        roomTypeRepository.Setup(repo => repo.GetRoomType(It.IsAny<long>())).ReturnsAsync(roomType);
        bookingRepository.Setup(repo => repo.BookRoom(It.IsAny<Booking>())).ReturnsAsync(0);

        await Assert.ThrowsAnyAsync<BadRequestException>(async () => await bookingService.BookRoomAsync(bookingRequestModel));
    }

    [Fact]
    public async Task BookRoom_ValidationFail()
    {
        var roomType = new RoomType();
        roomType.Price = 800;
        roomType.ServiceCharges = 10.2M;

        var bookingRequestModel = new BookingRequestModel();
        bookingRequestModel.CustomerContactNo = 1234562;
        bookingRequestModel.CustomerEmailId = "bigscalcom";
        bookingRequestModel.CheckInDate = DateTime.UtcNow;
        bookingRequestModel.CheckOutDate = DateTime.UtcNow;

        var result = await bookingService.BookRoomAsync(bookingRequestModel);
        Assert.True(result.Item2 != null);
    }
}
