using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Admin.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Genre> BookGenres { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Copyright> Copyrights { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<BookReview> BookReviews { get; set; }
    public DbSet<Category> BookCategories { get; set; }
    public DbSet<ShippingAddress> ShippingAddresses { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    DatabaseFacade Database { get; }
}