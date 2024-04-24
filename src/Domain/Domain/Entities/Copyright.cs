using Domain.Common.BaseEntities;
using Domain.Enums;

namespace Domain.Entities;

public class Copyright : AdminAuditableBaseEntity
{
    public Guid BookId { get; set; }
    public string? Text { get; set; }
    public int CopyrightYear { get; set; }
    public required string CopyrightHolder { get; set; }
    public CopyrightTypeEnum Type { get; set; }
}