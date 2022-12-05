using Hotel.DataLayer.Entities;
using Hotel.ServiceLayer.RequestModels;

namespace Hotel.ServiceLayer.Builder;

public class ContactUsBuilder
{
    public static ContactUs Build(ContactUsRequestModel model)
    {
        return new ContactUs(model.CustomerName, model.CustomerEmailId, model.CustomerContactNo, model.Description);
    }
}
