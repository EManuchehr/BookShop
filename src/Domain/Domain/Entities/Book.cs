using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class Book : AdminAuditableBaseEntity
{
    public required string Title { get; set; }
    public Guid PublisherId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid GenreId { get; set; }
    public string? Isbn { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public decimal Price { get; set; }
    public uint StockQuantity { get; set; }
    public DateOnly PublishedDate { get; set; }
    public int? PageCount { get; set; }
    public string? ImageUrl { get; set; }

    public Genre? Genre { get; set; }
    public Category? Category { get; set; }
    public Publisher? Publisher { get; set; }
    public ICollection<Author>? BookAuthors { get; set; }
    public ICollection<BookReview>? Reviews { get; set; } 
    public ICollection<Copyright>? Copyrights { get; set; }
}