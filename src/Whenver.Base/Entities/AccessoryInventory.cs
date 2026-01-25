using Whenver.Base.Models;

namespace Whenver.Base.Entities;

public class AccessoryInventory : BaseEntity<Guid>
{
    public Guid? AccessoryId { get; set; }
    public int? QuantityInStock  { get; set; }
    public string Color { get; set; }
    public DateTime? LastStockUpdate { get; set; }
    public Accessory Accessory { get; set; }
}