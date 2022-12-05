namespace Hotel.DataLayer.Entities;

public class RoomType
{
    public long Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int AdultCapacity { get; set; }

    public string Description { get; set; }

    public int ChildrenCapacity { get; set; }

    public long NoOfRooms { get; set; }

    public decimal ServiceCharges { get; set; }

    public string ImagePath { get; set; }
}
