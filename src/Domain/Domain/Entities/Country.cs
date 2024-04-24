using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class Country : AdminAuditableBaseEntity
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    public bool IsActive { get; set; }
    
    public ICollection<City>? Cities { get; set; }
}