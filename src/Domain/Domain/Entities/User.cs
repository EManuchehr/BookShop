using Domain.Common.BaseEntities;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser<Guid>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? MiddleName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public bool IsActive { get; set; }

    public ICollection<ShippingAddress>? ShippingAddresses { get; set; }
}