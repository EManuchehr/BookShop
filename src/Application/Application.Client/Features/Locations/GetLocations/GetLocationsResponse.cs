namespace Application.Client.Features.Locations.GetLocations;

public record GetLocationsResponse
{
    public Guid Id { get; init; }
    public required string Address { get; init; }
    public bool IsActive { get; init; }
    public required string Latitude { get; init; }
    public required string Longitude { get; init; }

    public GetLocationsResponseCity? City { get; init; }
    public GetLocationsResponseCountry? Country { get; init; }
}

public record GetLocationsResponseCity
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
}

public record GetLocationsResponseCountry
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
}