using Whenver.Base.Models;

namespace Whenver.Base.Entities;

public class ProductFabric : BaseEntity<Guid>
{
    public Guid ProductId { get; set; }
    public string FabricMaterial { get; set; }
    public int FabricCompositionPercentage { get; set; }
    public int Weight { get; set; }
    public int Shrinkage { get; set; }
    public bool? IsWrinkleResistant { get; set; }
    public bool? IsAntibacterial { get; set; }
    public bool? IsUVProtection { get; set; }
    public virtual Product Product { get; set; }

}