using AutoMapper;
using Hotel.DataLayer.Entities;
using Hotel.ServiceLayer.ResponseModels;

namespace Hotel.Configurations;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<RoomType, RoomTypeResponseModel>();
        CreateMap<Booking, BookingResponseModel>()
                            .ForMember(x => x.RoomType, opt => opt.MapFrom(src => src.RoomType.Name))
                            .ForMember(x => x.Price, opt => opt.MapFrom(src => src.RoomType.Price))
                            .ForMember(x => x.ServiceCharge, opt => opt.MapFrom(src => src.RoomType.ServiceCharges));
    }
}
