namespace Hotel.ServiceLayer.RequestModels;

public record BookingRequestModel
{
    public long RoomTypeId { get; set; }

    public string CustomerName { get; set; }

    public long CustomerContactNo { get; set; }

    public string CustomerEmailId { get; set; }

    public int NoOfRooms { get; set; }

    public int NoOfAdults { get; set; }

    public int NoOfChildren { get; set; }

    public DateTime CheckInDate { get; set; }

    public DateTime CheckOutDate { get; set; }

}
