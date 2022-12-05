using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ServiceLayer.ResponseModels;

public record RoomTypeResponseModel
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
