using Hotel.DataLayer.Entities;

namespace Hotel.DataLayer.IRepositories;

public interface IContactRepository
{
    Task<int> ContactUs(ContactUs contactUs);
}
