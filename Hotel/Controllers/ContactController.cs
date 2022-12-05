using Hotel.ServiceLayer.IService;
using Hotel.ServiceLayer.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpPost("/api/contactUs")]
    public async Task<IActionResult> ContactUs(ContactUsRequestModel contactUsRequestModel)
    {
        var result = await _contactService.ContactUs(contactUsRequestModel);
        return result == string.Empty ? Ok("Our executive will contact you shortly!") : BadRequest(result);
    }
}