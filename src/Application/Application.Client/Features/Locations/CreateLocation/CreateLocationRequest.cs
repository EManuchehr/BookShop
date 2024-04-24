namespace Application.Client.Features.Locations.CreateLocation;

public record CreateLocationRequest
{
    public required string Address { get; init; }
    public Guid CityId { get; init; }
    public Guid CountryId { get; init; }
    public bool IsActive { get; init; }
    public required string Latitude { get; init; }
    public required string Longitude { get; init; }
}