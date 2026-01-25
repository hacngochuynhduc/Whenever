using Whenver.Base.Models;

namespace Whenver.Base.Entities;

public class Colors : BaseEntity<Guid>
{
    public string ColorName  { get; set; }
    public string HexValue  { get; set; }
    public bool DefaultColor { get; set; }
    public string Description  { get; set; }
    
    public virtual ICollection<ProductColor> ProductColors { get; set; } = new  List<ProductColor>();
}