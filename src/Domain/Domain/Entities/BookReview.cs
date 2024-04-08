using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class BookReview : CommonAuditableBaseEntity
{
    public Guid BookId { get; set; }
    public int Rating { get; set; }
    public string? Review { get; set; }
    
    public Book? Book { get; set; }
}