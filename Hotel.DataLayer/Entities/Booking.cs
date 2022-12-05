using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.DataLayer.Entities;

public class Booking : Audit
{
    [Key]
    public long Id { get; set; }

    public long RoomTypeId { get; set; }

    public string CustomerName { get; set; }

    public long CustomerContactNo { get; set; }

    public string CustomerEmailId { get; set; }

    public int NoOfRooms { get; set; }

    public int NoOfAdults { get; set; }

    public int NoOfChildren { get; set; }

    public DateTime CheckInDate { get; set; }

    public DateTime CheckOutDate { get; set; }

    public decimal TotalAmount { get; set; }

    [ForeignKey("RoomTypeId")]
    public RoomType RoomType { get; set; }


    protected Booking()
    {

    }

    public Booking(long roomTypeId, string customerName, long customerContactNo, string customerEmailId, int noOfRooms, int noOfAdults, int noOfChildren, DateTime checkInDate, DateTime checkOutDate, decimal totalAmount)
    {        
        RoomTypeId = roomTypeId;
        CustomerName = customerName;
        CustomerContactNo = customerContactNo;
        CustomerEmailId = customerEmailId;
        NoOfRooms = noOfRooms;
        NoOfAdults = noOfAdults;
        NoOfChildren = noOfChildren;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        TotalAmount = totalAmount;
        CreatedOn = DateTime.UtcNow;
    }
}
