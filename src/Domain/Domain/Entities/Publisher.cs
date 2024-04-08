using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class Publisher : AdminAuditableBaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public Guid LocationId { get; set; }

    public Location? Location { get; set; }
}