using Whenver.Base.Models;

namespace Whenver.Base.Entities;

public class AccessoryCategory : BaseEntity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }
}