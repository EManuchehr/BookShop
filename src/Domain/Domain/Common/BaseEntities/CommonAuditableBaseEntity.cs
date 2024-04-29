namespace Domain.Common.BaseEntities;

public class CommonAuditableBaseEntity : BaseEntity
{
    public Guid? CreatedByUserId { get; set; }
    public Guid? UpdatedByUserId { get; set; }
    public Guid? CreatedByAdminUserId { get; set; }
    public Guid? UpdatedByAdminUserId { get; set; }
}