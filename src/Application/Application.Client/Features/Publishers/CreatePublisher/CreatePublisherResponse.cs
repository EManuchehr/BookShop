namespace Application.Client.Features.Publishers.CreatePublisher;

public record CreatePublisherResponse
{
    public Guid LocationId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }

    public CreatePublisherResponseLocation? Location { get; set; }
}

public record CreatePublisherResponseLocation
{
    public Guid Id { get; init; }
    public required string Address { get; init; }
    public bool IsActive { get; init; }
    public required string Latitude { get; init; }
    public required string Longitude { get; init; }

    public CreatePublisherResponseCity? City { get; init; }
    public CreatePublisherResponseCountry? Country { get; init; }
}

public record CreatePublisherResponseCity
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
}

public record CreatePublisherResponseCountry
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
}