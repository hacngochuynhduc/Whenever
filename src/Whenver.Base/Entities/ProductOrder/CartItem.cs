using System.Drawing;
using Whenver.Base.Models;

namespace Whenver.Base.Entities.ProductOrder;

public class CartItem : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public Guid? ProductId { get; set; }
    public Guid? ColorId { get; set; }
    public Guid? SizeId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public Guid? AccessoryId { get; set; }
    public CartItemType ItemType { get; set; }
    
    public virtual PersonalizationUser  User { get; set; }
    public virtual Product Product { get; set; }
    public virtual Colors Color { get; set; }
    public virtual Sizes Size { get; set; }
    public virtual Accessory Accessory { get; set; }
}

public enum CartItemType
{
    Product =0,
    Accessory=1
}