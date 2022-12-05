using Hotel.ServiceLayer.IService;
using Hotel.ServiceLayer.RequestModels;
using Hotel.ServiceLayer.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost("/api/bookRoom")]
    public async Task<IActionResult> BookRoom(BookingRequestModel bookingRequestModel)
    {
        var result = await _bookingService.BookRoomAsync(bookingRequestModel);
        return result.Item1 is not NullBookingResponseModel ? Ok(result.Item1) : BadRequest(result.Item2);
    }
}