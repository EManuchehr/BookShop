using AutoMapper;
using Domain.Entities;

namespace Application.Client.Features.Publishers.GetPublisher;

public class GetPublisherMapper : Profile
{
    public GetPublisherMapper()
    {
        CreateMap<Publisher, GetPublisherResponse>()
            .ForMember(x => x.Location, opt =>
                opt.MapFrom(x => x.Location));

        CreateMap<Location, GetPublisherResponseLocation>()
            .ForMember(x => x.City, opt =>
                opt.MapFrom(x => x.City))
            .ForMember(x => x.Country, opt =>
                opt.MapFrom(x => x.Country));
    }
}