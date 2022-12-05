using FluentValidation;
using Hotel.DataLayer.IRepositories;
using Hotel.ServiceLayer.RequestModels;

namespace Hotel.ServiceLayer.Validation;

public class BookingRequestValidation : AbstractValidator<BookingRequestModel>
{
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly IBookingRepository _bookingRepository;

    public BookingRequestValidation(IRoomTypeRepository roomTypeRepository, IBookingRepository bookingRepository)
    {
        _roomTypeRepository = roomTypeRepository;
        _bookingRepository = bookingRepository;
        RuleFor(x => x.CustomerContactNo).NotEmpty().WithMessage("Please provide Contact No.").NotEqual(10).WithMessage("Inavlid Contact No.");
        RuleFor(x => x.CustomerEmailId).EmailAddress().NotEmpty().WithMessage("Please provide Email Address.");
        RuleFor(x => x.CheckInDate).GreaterThanOrEqualTo(DateTime.UtcNow.Date).WithMessage("Please select valid Date.");
        RuleFor(x => x.CheckOutDate).NotEmpty().WithMessage("Please select Checkout Date.")
            .GreaterThan(x => x.CheckInDate.Date)
                            .WithMessage("Checkout date must after Checkin date.");
        RuleFor(x => x.NoOfAdults).MustAsync(NoOfAdultsMustBeLessThen).WithMessage(x => $"No Of Adults MustBe Less Then {x.NoOfAdults}");
        RuleFor(x => x.NoOfChildren).MustAsync(NoOfChildrenMustBeLessThen).WithMessage(x => $"No Of Children MustBe Less Then {x.NoOfChildren}");
        RuleFor(x => x.NoOfRooms).MustAsync(CheckAvailableRooms).WithMessage(x => $"No rooms are available.");
    }

    private async Task<bool> NoOfAdultsMustBeLessThen(BookingRequestModel model, int noOfAdults, CancellationToken cancellationToken)
    {
        var roomtype = await _roomTypeRepository.GetRoomType(model.RoomTypeId);
        return (roomtype.AdultCapacity * model.NoOfRooms) >= model.NoOfAdults;
    }

    private async Task<bool> NoOfChildrenMustBeLessThen(BookingRequestModel model, int noOfChildren, CancellationToken cancellationToken)
    {
        var roomType = await _roomTypeRepository.GetRoomType(model.RoomTypeId);
        return (roomType.ChildrenCapacity * model.NoOfRooms) >= noOfChildren;
    }

    private async Task<bool> CheckAvailableRooms(BookingRequestModel model, int noOfRooms, CancellationToken cancellationToken)
    {
        var totalRooms = (await _roomTypeRepository.GetRoomType(model.RoomTypeId)).NoOfRooms;
        var bookedRooms = (await _bookingRepository.GetBookings(model.RoomTypeId)).Count;
        var availableRooms = totalRooms - bookedRooms;
        return availableRooms >= noOfRooms;
    }

}
