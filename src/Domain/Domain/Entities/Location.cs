using Domain.Common.BaseEntities;

namespace Domain.Entities;

public class Location : AdminAuditableBaseEntity
{
    public required string Address { get; set; }
    public Guid CityId { get; set; }
    public Guid CountryId { get; set; }
    public bool IsActive { get; set; }
    public required string Latitude { get; set; }
    public required string Longitude { get; set; }

    public City? City { get; set; }
    public Country? Country { get; set; }
}