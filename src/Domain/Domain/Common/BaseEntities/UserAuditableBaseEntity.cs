namespace Domain.Common.BaseEntities;

public abstract class UserAuditableBaseEntity : BaseEntity
{
    public Guid CreatedByUserId { get; set; }
    public Guid? UpdatedByUserId { get; set; }
}