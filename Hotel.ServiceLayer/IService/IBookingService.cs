using Hotel.ServiceLayer.RequestModels;
using Hotel.ServiceLayer.ResponseModels;

namespace Hotel.ServiceLayer.IService;

public interface IBookingService
{
    Task<(BookingResponseModel, string)> BookRoomAsync(BookingRequestModel bookingRequestModel);
}
