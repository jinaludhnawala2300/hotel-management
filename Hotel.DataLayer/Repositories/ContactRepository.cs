using Hotel.DataLayer.Entities;
using Hotel.DataLayer.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DataLayer.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly HotelContext _context;
        public ContactRepository(HotelContext context)
        {
            _context = context;
        }       

        public async Task<int> ContactUs(ContactUs contactUs)
        {
            await _context.ContactUs.AddAsync(contactUs);
            return await _context.SaveChangesAsync();
        }
    }
}
