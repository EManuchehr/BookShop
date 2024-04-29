namespace Application.Client.Features.Publishers.GetPublishers;

public record GetPublishersResponse
{
    public Guid Id { get; init; }
    public Guid LocationId { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public bool IsActive { get; init; }

    public GetPublishersResponseLocation? Location { get; init; }
}

public record GetPublishersResponseLocation
{
    public Guid Id { get; init; }
    public required string Address { get; init; }
    public bool IsActive { get; init; }
    public required string Latitude { get; init; }
    public required string Longitude { get; init; }

    public GetPublishersResponseCity? City { get; init; }
    public GetPublishersResponseCountry? Country { get; init; }
}

public record GetPublishersResponseCity
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
}

public record GetPublishersResponseCountry
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
}