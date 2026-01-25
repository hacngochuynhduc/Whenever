using Whenver.Base.Models;

namespace Whenver.Base.Entities;

public class Images : BaseEntity<Guid>
{
    public Guid ProductId { get; set; }
    public string ImageName { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public bool IsMainImage { get; set; }
    public virtual Product Product { get; set; }
}