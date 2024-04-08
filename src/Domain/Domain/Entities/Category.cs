using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class Category : AdminAuditableBaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}