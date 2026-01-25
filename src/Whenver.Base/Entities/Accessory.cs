using Whenver.Base.Entities.ProductOrder;
using Whenver.Base.Models;

namespace Whenver.Base.Entities;

public class Accessory : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal OriginalPrice { get; set; }
    public Guid? AccessoryCategoryId { get; set; }
    public string ImageUrl { get; set; }
    public AccessoryCategory AccessoryCategory { get; set; }
    public ICollection<AccessoryCategory> AccessoryCategories { get; set; } = new List<AccessoryCategory>();
    public ICollection<OrderItem> OrderItems { get; set; } = new  List<OrderItem>();
}