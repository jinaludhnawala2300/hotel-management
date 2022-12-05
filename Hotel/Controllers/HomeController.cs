using Hotel.ServiceLayer.IService;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRoomTypeService _roomTypeService;

        public HomeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        public async Task<IActionResult> Index()
        {
            var roomTypes = await _roomTypeService.GetRoomTypes();
            ViewBag.RoomTypes = roomTypes;
            return View();
        }

        [Route("bookingForm")]
        public async Task<IActionResult> BookingForm(int? roomType)
        {
            ViewBag.Id = roomType ?? 0;
            var roomTypes = await _roomTypeService.GetRoomTypes();
            ViewBag.RoomTypes = roomTypes;
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
