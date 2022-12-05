namespace Hotel.ServiceLayer.ResponseModels;

public record BookingResponseModel
{
    public string RoomType { get; set; }

    public string CustomerName { get; set; }

    public long CustomerContactNo { get; set; }

    public string CustomerEmailId { get; set; }

    public int NoOfRooms { get; set; }

    public int NoOfAdults { get; set; }

    public int NoOfChildren { get; set; }

    public DateTime CheckInDate { get; set; }

    public DateTime CheckOutDate { get; set; }

    public decimal Price { get; set; }

    public decimal ServiceCharge { get; set; }

    public decimal TotalAmount { get; set; }
}

public record NullBookingResponseModel : BookingResponseModel { }
