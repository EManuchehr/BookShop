using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class City : AdminAuditableBaseEntity
{
    public required string Name { get; set; }
    public Guid CountryId { get; set; }
    public bool IsActive { get; set; }

    public Country? Country { get; set; }
}