using Whenver.Base.Models;

namespace Whenver.Base.Entities;

public class ProductColor : BaseEntity<Guid>
{
    public Guid ColorId { get; set; }
    public Guid ProductId { get; set; }
    public virtual Colors Colors { get; set; }
    public virtual Product Product { get; set; }
}