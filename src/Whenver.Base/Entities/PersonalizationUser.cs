using Whenver.Base.Entities.ProductOrder;
using Whenver.Base.Models;

namespace Whenver.Base.Entities;

public class PersonalizationUser : BaseEntity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string AvatarUrl { get; set; }
    public string PhoneNumber { get; set; }
    public string StressAddress  { get; set; }
    public string Province { get; set; }
    public string Ward { get; set; }
    public DateTime? RegistrationDate { get; set; }

    public DateTime? LastLogin { get; set; }
    public DateTime? FirstLogin { get; set; }
    public string? GoogleId { get; set; }
    public string? FacebookId { get; set; }
    
    public ICollection<Order> Orders { get; set; } = new  List<Order>();
    public ICollection<CartItem> CartItems { get; set; } = new  List<CartItem>();
    
    
}