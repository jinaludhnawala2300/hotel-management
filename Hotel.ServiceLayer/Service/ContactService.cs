using FluentValidation.Results;
using Hotel.DataLayer.IRepositories;
using Hotel.ServiceLayer.Builder;
using Hotel.ServiceLayer.Exceptions;
using Hotel.ServiceLayer.IService;
using Hotel.ServiceLayer.RequestModels;
using Hotel.ServiceLayer.Validation;

namespace Hotel.ServiceLayer.Service;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<string> ContactUs(ContactUsRequestModel contactUsRequestModel)
    {
        try
        {
            ContactUsRequestValidation validation = new ContactUsRequestValidation();
            ValidationResult validationResult = validation.Validate(contactUsRequestModel);

            if (!validationResult.IsValid)
            {
                var errorMessage = "";
                foreach (ValidationFailure validationFailure in validationResult.Errors)
                {
                    errorMessage += $"{validationFailure.ErrorMessage}\n";
                }
                return errorMessage;
            }

            var contactUs = ContactUsBuilder.Build(contactUsRequestModel);
            var count = await _contactRepository.ContactUs(contactUs);

            if (count == 0)
            {
                throw new BadRequestException("Submission Request Failed.");
            }

            return string.Empty;
        }
        catch (Exception)
        {
            throw;
        }

    }
}
