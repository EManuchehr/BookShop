using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class User : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? MiddleName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public bool IsActive { get; set; }

    public ICollection<ShippingAddress>? ShippingAddresses { get; set; }
}