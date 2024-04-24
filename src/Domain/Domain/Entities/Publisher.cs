using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class Publisher : AdminAuditableBaseEntity
{
    public Guid LocationId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }

    public Location? Location { get; set; }
}