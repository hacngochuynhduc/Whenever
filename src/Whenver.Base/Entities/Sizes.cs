using Whenver.Base.Models;

namespace Whenver.Base.Entities;

public class Sizes : BaseEntity<Guid>
{
    public string SizeName { get; set; }
    public string SizeDescription { get; set; }
    public string SizeChartUrl { get; set; }
    public bool DefaultSize { get; set; }
    public virtual ICollection<ProductSize> ProductSizes { get; set; } = new  List<ProductSize>();
}