using Whenver.Base.Models;

namespace Whenver.Base.Entities.ProductOrder;

public class OrderItem : BaseEntity<Guid>
{
    public Guid OrderId { get; set; }
    public Guid? ProductId { get; set; }
    public Guid? AccessoryId { get; set; }
    public Guid? ColorId { get; set; }
    public Guid? SizeId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal OriginalPrice { get; set; }
    public virtual Order Order { get; set; }
    public virtual Product Product { get; set; } 
    public virtual Accessory Accessory { get; set; }
    public virtual Colors Colors { get; set; }
    public virtual Sizes Sizes { get; set; }
}