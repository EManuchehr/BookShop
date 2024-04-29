using AutoMapper;
using Domain.Entities;

namespace Application.Client.Features.Publishers.GetPublishers;

public class GetPublishersMapper : Profile
{
    public GetPublishersMapper()
    {
        CreateMap<Publisher, GetPublishersResponse>();
        
        CreateMap<Location, GetPublishersResponseLocation>()
            .ForMember(x => x.City, opt =>
                opt.MapFrom(x => x.City))
            .ForMember(x => x.Country, opt =>
                opt.MapFrom(x => x.Country));
    }
}