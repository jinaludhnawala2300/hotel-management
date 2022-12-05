using Hotel.DataLayer.Entities;
using Hotel.ServiceLayer.RequestModels;

namespace Hotel.ServiceLayer.Builder;

public class BookingBuilder
{
    public static Booking Build(BookingRequestModel model, decimal totalAmount)
    {
        return new Booking(model.RoomTypeId, model.CustomerName, model.CustomerContactNo, model.CustomerEmailId, model.NoOfRooms, model.NoOfAdults, model.NoOfChildren, model.CheckInDate, model.CheckOutDate, totalAmount);
    }
}
