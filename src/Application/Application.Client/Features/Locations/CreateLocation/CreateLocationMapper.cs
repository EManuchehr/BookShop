using AutoMapper;
using Domain.Entities;

namespace Application.Client.Features.Locations.CreateLocation;

public class CreateLocationMapper : Profile
{
    public CreateLocationMapper()
    {
        CreateMap<CreateLocationRequest, Location>();

        CreateMap<Location, CreateLocationResponse>();
    }
}