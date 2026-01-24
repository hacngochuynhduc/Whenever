using Whenver.Base.Models;

namespace Whenver.Base.Entities;

public class Category : BaseEntity<Guid>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public ICollection<Product> Products { get; set; } = new  List<Product>();
}