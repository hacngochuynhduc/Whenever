using Whenver.Base.Models;

namespace Whenver.Base.Entities;

public class ProductInventory : BaseEntity<Guid>
{
    public Guid ProductId { get; set; }
    public Guid? SizeId { get; set; }
    public Guid? ColorId { get; set; }
      
    /// <summary>
    /// Current available quantity in stock
    /// </summary>
    public int QuantityInStock { get; set; }
    
    /// <summary>
    /// Reserved quantity (in cart/pending orders)
    /// </summary>
    public int QuantityReserved { get; set; }
    
    /// <summary>
    /// Total sold quantity (lifetime)
    /// </summary>
    public int QuantitySold { get; set; }
    /// <summary>
    /// Low stock threshold - alert vendor when stock below this
    /// </summary>
    public int LowStockThreshold { get; set; } = 10;
    
    public bool EnableLowStockAlert { get; set; } = true;
    /// <summary>
    /// Last time vendor restocked
    /// </summary>
    public DateTime? LastRestockDate { get; set; }
    
    /// <summary>
    /// Last time stock went out (sold out)
    /// </summary>
    public DateTime? LastStockOutDate { get; set; }
    /// <summary>
    /// Notes for vendor
    /// </summary>
    public string? Notes { get; set; }
    
    public virtual Product Product { get; set; }
    public virtual Sizes? Size { get; set; }
    public virtual Colors? Color { get; set; }
}
    
    