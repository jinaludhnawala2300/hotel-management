using Hotel.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DataLayer;

public class HotelContext : DbContext
{
    public HotelContext(DbContextOptions<HotelContext> options) : base(options)
    {

    }
    public DbSet<RoomType> RoomType { get; set; }
    public DbSet<Booking> Booking { get; set; }
    public DbSet<ContactUs> ContactUs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RoomType>().HasData(new List<RoomType> {
                new RoomType{
                    Id = 1,
                    Name = "Double Delux Room",
                    AdultCapacity = 2,
                    ChildrenCapacity = 2,
                    NoOfRooms = 10,
                    Price = 250,
                    ServiceCharges = 15,
                    Description = "Breakfast Included",
                    ImagePath = "image/room1.jpg"
                },
                new RoomType{
                    Id = 2,
                    Name = "Single Delux Room",
                    AdultCapacity = 2,
                    ChildrenCapacity = 1,
                    NoOfRooms = 15,
                    Price = 200,
                    ServiceCharges = 15,
                    Description = "Breakfast Included",
                    ImagePath = "image/room2.jpg"
                },
                new RoomType{
                    Id = 3,
                    Name = "Honeymoon Suit",
                    AdultCapacity = 2,
                    ChildrenCapacity = 0,
                    NoOfRooms = 10,
                    Price = 750,
                    ServiceCharges = 15,
                    Description = "Breakfast Included",
                    ImagePath = "image/room3.jpg"
                },
                new RoomType{
                    Id = 4,
                    Name = "Economy Double",
                    AdultCapacity = 2,
                    ChildrenCapacity = 1,
                    NoOfRooms = 15,
                    Price = 200,
                    ServiceCharges = 15,
                    Description = "Breakfast Included",
                    ImagePath = "image/room4.jpg"
                }
            });
    }
}