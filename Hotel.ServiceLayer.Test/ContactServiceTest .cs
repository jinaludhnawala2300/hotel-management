using AutoMapper;
using Hotel.DataLayer.Entities;
using Hotel.DataLayer.IRepositories;
using Hotel.ServiceLayer.Exceptions;
using Hotel.ServiceLayer.RequestModels;
using Hotel.ServiceLayer.ResponseModels;
using Hotel.ServiceLayer.Service;
using Moq;

namespace Hotel.ServiceLayer.Test;

public class ContactServiceTest
{
    Mock<IContactRepository> contactRepository;
    ContactService contactService;

    public ContactServiceTest()
    {        
        this.contactRepository = new Mock<IContactRepository>();        
        this.contactService = new ContactService(contactRepository.Object);
    }

    [Fact]
    public async Task ContactUs()
    {       
        var contactUs = new ContactUs(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>(), It.IsAny<string>());
        var contactUsRequestModel = new ContactUsRequestModel();
        contactUsRequestModel.CustomerContactNo = 1234567892;
        contactUsRequestModel.CustomerEmailId = "bigscal.@com";
        contactUsRequestModel.Description = "What are the checkin checkout timings?";

        contactRepository.Setup(repo => repo.ContactUs(It.IsAny<ContactUs>())).ReturnsAsync(1).Callback(() => contactUs.Id = 1);
       
        var result = await contactService.ContactUs(contactUsRequestModel);
        Assert.True(contactUs.Id == 1);
    }

    [Fact]
    public async Task ContactUs_MustFail()
    {
        var contactUs = new ContactUs(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>(), It.IsAny<string>());
        var contactUsRequestModel = new ContactUsRequestModel();
        contactUsRequestModel.CustomerContactNo = 1234567892;
        contactUsRequestModel.CustomerEmailId = "bigscal.@com";
        contactUsRequestModel.Description = "What are the checkin checkout timings?";

        contactRepository.Setup(repo => repo.ContactUs(It.IsAny<ContactUs>())).ReturnsAsync(0);
       
        await Assert.ThrowsAnyAsync<BadRequestException>(async () => await contactService.ContactUs(contactUsRequestModel));
    }

    [Fact]
    public async Task ContactUs_ValidationFail()
    {
        var contactUs = new ContactUs(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<long>(), It.IsAny<string>());
        var contactUsRequestModel = new ContactUsRequestModel();
        contactUsRequestModel.CustomerContactNo = 123456789212;
        contactUsRequestModel.CustomerEmailId = "bigscalcom";
        contactUsRequestModel.Description = "";

        contactRepository.Setup(repo => repo.ContactUs(It.IsAny<ContactUs>())).ReturnsAsync(0);
       
        var result = await contactService.ContactUs(contactUsRequestModel);
        Assert.True(result != "");
    }
}
