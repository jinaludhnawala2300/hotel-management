using Hotel.ServiceLayer.IService;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomTypeController : ControllerBase
{
    private readonly IRoomTypeService _roomTypeService;

    public RoomTypeController(IRoomTypeService roomTypeService)
    {
        _roomTypeService = roomTypeService;
    }


    [HttpGet]
    [Route("/api/roomTypes")]
    public async Task<IActionResult> GetRoomTypes()
    {
        var roomTypes = await _roomTypeService.GetRoomTypes();
        return Ok(roomTypes);
    }   
}