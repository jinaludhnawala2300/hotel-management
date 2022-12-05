using FluentValidation;
using Hotel.ServiceLayer.RequestModels;

namespace Hotel.ServiceLayer.Validation;

public class ContactUsRequestValidation : AbstractValidator<ContactUsRequestModel>
{
    public ContactUsRequestValidation()
    {
        RuleFor(x => x.CustomerContactNo).NotEmpty().WithMessage("Please provide Contact No.").LessThan(10).WithMessage("Inavlid Contact No.").GreaterThan(10).WithMessage("Inavlid Contact No.");
        RuleFor(x => x.CustomerEmailId).NotEmpty().WithMessage("Please provide Email Address").EmailAddress().WithMessage("Please provide valid Email Address.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Please provide description.");        
    }
}
