using Hotel.ServiceLayer.RequestModels;

namespace Hotel.ServiceLayer.IService;

public interface IContactService
{
    Task<string> ContactUs(ContactUsRequestModel contactUsRequestModel);
}
