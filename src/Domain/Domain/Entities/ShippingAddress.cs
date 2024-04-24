using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class ShippingAddress : UserAuditableBaseEntity
{
    public Guid LocationId { get; set; }
    public string? PostalCode { get; set; }
    public bool IsPrimary { get; set; }
    public bool IsActive { get; set; }
    
    public Location? Location { get; set; }
}