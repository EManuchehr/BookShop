using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BookStore");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "BookStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookCategories",
                schema: "BookStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookCategories_Users_CreatedByAdminUserId",
                        column: x => x.CreatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategories_Users_UpdatedByAdminUserId",
                        column: x => x.UpdatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookGenres",
                schema: "BookStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookGenres_Users_CreatedByAdminUserId",
                        column: x => x.CreatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenres_Users_UpdatedByAdminUserId",
                        column: x => x.UpdatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "BookStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Users_CreatedByAdminUserId",
                        column: x => x.CreatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countries_Users_UpdatedByAdminUserId",
                        column: x => x.UpdatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                schema: "BookStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Biography = table.Column<string>(type: "text", nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    DateOfDeath = table.Column<DateOnly>(type: "date", nullable: true),
                    OriginCountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_Countries_OriginCountryId",
                        column: x => x.OriginCountryId,
                        principalSchema: "BookStore",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Authors_Users_CreatedByAdminUserId",
                        column: x => x.CreatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Authors_Users_UpdatedByAdminUserId",
                        column: x => x.UpdatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "BookStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "BookStore",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cities_Users_CreatedByAdminUserId",
                        column: x => x.CreatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cities_Users_UpdatedByAdminUserId",
                        column: x => x.UpdatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "BookStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Latitude = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Longitude = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "BookStore",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "BookStore",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_Users_CreatedByAdminUserId",
                        column: x => x.CreatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locations_Users_UpdatedByAdminUserId",
                        column: x => x.UpdatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                schema: "BookStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publishers_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "BookStore",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Publishers_Users_CreatedByAdminUserId",
                        column: x => x.CreatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publishers_Users_UpdatedByAdminUserId",
                        column: x => x.UpdatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShippingAddresses",
                schema: "BookStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false),
                    PostalCode = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    IsPrimary = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingAddresses_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "BookStore",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShippingAddresses_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShippingAddresses_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "BookStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PublisherId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    GenreId = table.Column<Guid>(type: "uuid", nullable: false),
                    Isbn = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    StockQuantity = table.Column<long>(type: "bigint", nullable: false),
                    PublishedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PageCount = table.Column<int>(type: "integer", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_BookCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "BookStore",
                        principalTable: "BookCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_BookGenres_GenreId",
                        column: x => x.GenreId,
                        principalSchema: "BookStore",
                        principalTable: "BookGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalSchema: "BookStore",
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Users_CreatedByAdminUserId",
                        column: x => x.CreatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Users_UpdatedByAdminUserId",
                        column: x => x.UpdatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "BookStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShippingAddressId = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_ShippingAddresses_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalSchema: "BookStore",
                        principalTable: "ShippingAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Users_CreatedByAdminUserId",
                        column: x => x.CreatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UpdatedByAdminUserId",
                        column: x => x.UpdatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                schema: "BookStore",
                columns: table => new
                {
                    BookAuthorsId = table.Column<Guid>(type: "uuid", nullable: false),
                    BooksId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.BookAuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_BookAuthorsId",
                        column: x => x.BookAuthorsId,
                        principalSchema: "BookStore",
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BooksId",
                        column: x => x.BooksId,
                        principalSchema: "BookStore",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                schema: "BookStore",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "BookStore",
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "BookStore",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Users_CreatedByAdminUserId",
                        column: x => x.CreatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Users_UpdatedByAdminUserId",
                        column: x => x.UpdatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookReviews",
                schema: "BookStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Review = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookReviews_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "BookStore",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookReviews_Users_CreatedByAdminUserId",
                        column: x => x.CreatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookReviews_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookReviews_Users_UpdatedByAdminUserId",
                        column: x => x.UpdatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookReviews_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Copyrights",
                schema: "BookStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    CopyrightYear = table.Column<int>(type: "integer", nullable: false),
                    CopyrightHolder = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedByAdminUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Copyrights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Copyrights_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "BookStore",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Copyrights_Users_CreatedByAdminUserId",
                        column: x => x.CreatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Copyrights_Users_UpdatedByAdminUserId",
                        column: x => x.UpdatedByAdminUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                schema: "BookStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedByUserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "BookStore",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "BookStore",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Users_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalSchema: "BookStore",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksId",
                schema: "BookStore",
                table: "AuthorBook",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_CreatedByAdminUserId",
                schema: "BookStore",
                table: "Authors",
                column: "CreatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_OriginCountryId",
                schema: "BookStore",
                table: "Authors",
                column: "OriginCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_UpdatedByAdminUserId",
                schema: "BookStore",
                table: "Authors",
                column: "UpdatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorId",
                schema: "BookStore",
                table: "BookAuthors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_CreatedByAdminUserId",
                schema: "BookStore",
                table: "BookAuthors",
                column: "CreatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_UpdatedByAdminUserId",
                schema: "BookStore",
                table: "BookAuthors",
                column: "UpdatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_CreatedByAdminUserId",
                schema: "BookStore",
                table: "BookCategories",
                column: "CreatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_UpdatedByAdminUserId",
                schema: "BookStore",
                table: "BookCategories",
                column: "UpdatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenres_CreatedByAdminUserId",
                schema: "BookStore",
                table: "BookGenres",
                column: "CreatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenres_UpdatedByAdminUserId",
                schema: "BookStore",
                table: "BookGenres",
                column: "UpdatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_BookId",
                schema: "BookStore",
                table: "BookReviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_CreatedByAdminUserId",
                schema: "BookStore",
                table: "BookReviews",
                column: "CreatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_CreatedByUserId",
                schema: "BookStore",
                table: "BookReviews",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_UpdatedByAdminUserId",
                schema: "BookStore",
                table: "BookReviews",
                column: "UpdatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_UpdatedByUserId",
                schema: "BookStore",
                table: "BookReviews",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                schema: "BookStore",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CreatedByAdminUserId",
                schema: "BookStore",
                table: "Books",
                column: "CreatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                schema: "BookStore",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                schema: "BookStore",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_UpdatedByAdminUserId",
                schema: "BookStore",
                table: "Books",
                column: "UpdatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                schema: "BookStore",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CreatedByAdminUserId",
                schema: "BookStore",
                table: "Cities",
                column: "CreatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_UpdatedByAdminUserId",
                schema: "BookStore",
                table: "Cities",
                column: "UpdatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Copyrights_BookId",
                schema: "BookStore",
                table: "Copyrights",
                column: "BookId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Copyrights_CreatedByAdminUserId",
                schema: "BookStore",
                table: "Copyrights",
                column: "CreatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Copyrights_UpdatedByAdminUserId",
                schema: "BookStore",
                table: "Copyrights",
                column: "UpdatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CreatedByAdminUserId",
                schema: "BookStore",
                table: "Countries",
                column: "CreatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_UpdatedByAdminUserId",
                schema: "BookStore",
                table: "Countries",
                column: "UpdatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CityId",
                schema: "BookStore",
                table: "Locations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CountryId",
                schema: "BookStore",
                table: "Locations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CreatedByAdminUserId",
                schema: "BookStore",
                table: "Locations",
                column: "CreatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_UpdatedByAdminUserId",
                schema: "BookStore",
                table: "Locations",
                column: "UpdatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BookId",
                schema: "BookStore",
                table: "OrderItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CreatedByUserId",
                schema: "BookStore",
                table: "OrderItems",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                schema: "BookStore",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_UpdatedByUserId",
                schema: "BookStore",
                table: "OrderItems",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedByAdminUserId",
                schema: "BookStore",
                table: "Orders",
                column: "CreatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedByUserId",
                schema: "BookStore",
                table: "Orders",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAddressId",
                schema: "BookStore",
                table: "Orders",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UpdatedByAdminUserId",
                schema: "BookStore",
                table: "Orders",
                column: "UpdatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UpdatedByUserId",
                schema: "BookStore",
                table: "Orders",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_CreatedByAdminUserId",
                schema: "BookStore",
                table: "Publishers",
                column: "CreatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_LocationId",
                schema: "BookStore",
                table: "Publishers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Publishers_UpdatedByAdminUserId",
                schema: "BookStore",
                table: "Publishers",
                column: "UpdatedByAdminUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddresses_CreatedByUserId",
                schema: "BookStore",
                table: "ShippingAddresses",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddresses_LocationId",
                schema: "BookStore",
                table: "ShippingAddresses",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddresses_UpdatedByUserId",
                schema: "BookStore",
                table: "ShippingAddresses",
                column: "UpdatedByUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook",
                schema: "BookStore");

            migrationBuilder.DropTable(
                name: "BookAuthors",
                schema: "BookStore");

            migrationBuilder.DropTable(
                name: "BookReviews",
                schema: "BookStore");

            migrationBuilder.DropTable(
                name: "Copyrights",
                schema: "BookStore");

            migrationBuilder.DropTable(
                name: "OrderItems",
                schema: "BookStore");

            migrationBuilder.DropTable(
                name: "Authors",
                schema: "BookStore");

            migrationBuilder.DropTable(
                name: "Books",
                schema: "BookStore");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "BookStore");

            migrationBuilder.DropTable(
                name: "BookCategories",
                schema: "BookStore");

            migrationBuilder.DropTable(
                name: "BookGenres",
                schema: "BookStore");

            migrationBuilder.DropTable(
                name: "Publishers",
                schema: "BookStore");

            migrationBuilder.DropTable(
                name: "ShippingAddresses",
                schema: "BookStore");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "BookStore");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "BookStore");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "BookStore");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "BookStore");
        }
    }
}
