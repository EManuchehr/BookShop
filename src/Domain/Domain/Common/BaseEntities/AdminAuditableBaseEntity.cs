namespace Domain.Common.BaseEntities;

public class AdminAuditableBaseEntity : BaseEntity
{
    public Guid CreatedByAdminUserId { get; set; }
    public Guid? UpdatedByAdminUserId { get; set; }
}