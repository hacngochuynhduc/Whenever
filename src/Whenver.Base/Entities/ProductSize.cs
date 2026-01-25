using Whenver.Base.Models;

namespace Whenver.Base.Entities;

public class ProductSize : BaseEntity<Guid>
{
 
    public Guid ProductId { get; set; }
    public Guid SizeId { get; set; }
    public Guid? ProductColorId { get; set; }
    public virtual Product Product { get; set; }
    public virtual Sizes Sizes { get; set; }
    public virtual ProductColor ProductColor { get; set; }
}