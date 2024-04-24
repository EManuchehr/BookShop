using Domain.Entities;

namespace Domain.Common.BaseEntities;

public abstract class UserAuditableBaseEntity : BaseEntity
{
    public Guid CreatedByUserId { get; set; }
    public Guid? UpdatedByUserId { get; set; }

    public User? CreatedByUser { get; set; }
    public User? UpdatedByUser { get; set; }
}