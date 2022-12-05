namespace Hotel.DataLayer.Entities;

public class Audit
{
    public DateTime CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool IsDeleted { get; set; }
}
