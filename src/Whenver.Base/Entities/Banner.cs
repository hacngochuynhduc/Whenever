using Whenver.Base.Models;

namespace Whenver.Base.Entities;

public class Banner : BaseEntity<Guid>
{
    public string? ImageUrl { get; set; }
    public string? ThumbnailUrl { get; set; }
    public int? DisplayPriorirty { get; set; }
    public string Description { get; set; }
    
}