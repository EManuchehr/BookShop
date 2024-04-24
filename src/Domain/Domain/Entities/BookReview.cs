using Domain.Common.BaseEntities;
using Domain.Enums;

namespace Domain.Entities;

public class BookReview : CommonAuditableBaseEntity
{
    public Guid BookId { get; set; }
    public BookRatingEnum Rating { get; set; }
    public string? Review { get; set; }

    public Book? Book { get; set; }
}