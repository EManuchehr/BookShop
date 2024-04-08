using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class Author : AdminAuditableBaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? Biography { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public DateOnly? DateOfDeath { get; set; }
    public Guid OriginCountryId { get; set; }
    public bool IsActive { get; set; }

    public Country? OriginCountry { get; set; }
    public ICollection<Book> Books { get; set; } = new List<Book>();
}