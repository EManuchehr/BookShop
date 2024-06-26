using Domain.Common.BaseEntities;
using Domain.Enums;

namespace Domain.Entities;

public class Order : UserAuditableBaseEntity
{
    public Guid ShippingAddressId { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderStatusEnum Status { get; set; }
    
    public ShippingAddress? ShippingAddress { get; set; }
    public ICollection<OrderItem>? OrderItems { get; set; }
}