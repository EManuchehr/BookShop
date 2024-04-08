using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class Genre : AdminAuditableBaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    
    public ICollection<Book> Books { get; set; } = new List<Book>();
}