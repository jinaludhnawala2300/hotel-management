using AutoMapper;
using FluentValidation.Results;
using Hotel.DataLayer.IRepositories;
using Hotel.ServiceLayer.Builder;
using Hotel.ServiceLayer.Exceptions;
using Hotel.ServiceLayer.IService;
using Hotel.ServiceLayer.RequestModels;
using Hotel.ServiceLayer.ResponseModels;
using Hotel.ServiceLayer.Validation;

namespace Hotel.ServiceLayer.Service;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly IMapper _mapper;

    public BookingService(IBookingRepository bookingRepository, IRoomTypeRepository roomTypeRepository, IMapper mapper)
    {
        _bookingRepository = bookingRepository;
        _roomTypeRepository = roomTypeRepository;
        _mapper = mapper;
    }

    public async Task<(BookingResponseModel, string)> BookRoomAsync(BookingRequestModel bookingRequestModel)
    {
        try
        {
            BookingRequestValidation validation = new BookingRequestValidation(_roomTypeRepository, _bookingRepository);
            ValidationResult validationResult = await validation.ValidateAsync(bookingRequestModel);

            if (!validationResult.IsValid)
            {
                var errorMessage = "";
                foreach (ValidationFailure validationFailure in validationResult.Errors)
                {
                    errorMessage += $"{validationFailure.ErrorMessage}\n";
                }
                return (new NullBookingResponseModel(), errorMessage);
            }

            var roomType = await _roomTypeRepository.GetRoomType(bookingRequestModel.RoomTypeId);
            var amount = (roomType.Price * bookingRequestModel.NoOfRooms) * (bookingRequestModel.CheckOutDate.Subtract(bookingRequestModel.CheckInDate).Days);
            var totalAmount = amount + (amount * (roomType.ServiceCharges)) / 100;
            var booking = BookingBuilder.Build(bookingRequestModel, totalAmount);
            var count = await _bookingRepository.BookRoom(booking);

            if (count == 0)
            {
                throw new BadRequestException("Booking Failed.");
            }

            var result = _mapper.Map<BookingResponseModel>(booking);
            //result.Price = roomType.Price;
            //result.Tax = roomType.ServiceCharges;
            return (result, string.Empty);
        }
        catch (Exception)
        {
            throw;
        }

    }
}
