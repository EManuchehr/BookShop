namespace Application.Client.Features.Publishers.CreatePublisher;

public record CreatePublisherRequest
{
    public Guid LocationId { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public bool IsActive { get; init; }
}