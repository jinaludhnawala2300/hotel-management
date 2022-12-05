namespace Hotel.DataLayer.Entities;

public class ContactUs : Audit
{
    public int Id { get; set; }

    public string CustomerName { get; set; }

    public string CustomerEmailId { get; set; }

    public long CustomerContactNo { get; set; }

    public string Description { get; set; }

    protected ContactUs()
    {

    }

    public ContactUs(string customerName, string customerEmailId, long customerContactNo, string description)
    {
        CustomerName = customerName;
        CustomerEmailId = customerEmailId;
        CustomerContactNo = customerContactNo;
        Description = description;
        CreatedOn = DateTime.UtcNow;
    }
}
