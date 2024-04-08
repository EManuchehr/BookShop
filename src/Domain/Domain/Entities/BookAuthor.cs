using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class BookAuthor : AdminAuditableBaseEntity
{
    public Guid BookId { get; set; }
    public Guid AuthorId { get; set; }
}