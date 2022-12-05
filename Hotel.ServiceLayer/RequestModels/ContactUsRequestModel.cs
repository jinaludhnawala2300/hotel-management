namespace Hotel.ServiceLayer.RequestModels;

public record ContactUsRequestModel
{
    public string CustomerName { get; set; }

    public string CustomerEmailId { get; set; }

    public long CustomerContactNo { get; set; }

    public string Description { get; set; }
}

public record NullContactUsRequestModel : ContactUsRequestModel { }
