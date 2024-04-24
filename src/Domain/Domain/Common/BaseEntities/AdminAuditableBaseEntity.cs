using Domain.Entities;

namespace Domain.Common.BaseEntities;

public class AdminAuditableBaseEntity : BaseEntity
{
    public Guid CreatedByAdminUserId { get; set; }
    public Guid? UpdatedByAdminUserId { get; set; }
    
    public User? CreatedByAdminUser { get; set; }
    public User? UpdatedByAdminUser { get; set; }
}