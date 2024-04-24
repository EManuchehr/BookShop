using AutoMapper;
using Domain.Entities;

namespace Application.Client.Features.Locations.GetLocations;

public class GetLocationsMapper : Profile
{
    public GetLocationsMapper()
    {
        CreateMap<Location, GetLocationsResponse>()
            .ForMember(x => x.City, opt =>
                opt.MapFrom(src => src.City))
            .ForMember(x => x.Country, opt =>
                opt.MapFrom(src => src.Country));

        CreateMap<City, GetLocationsResponseCity>();

        CreateMap<Country, GetLocationsResponseCountry>();
    }
}