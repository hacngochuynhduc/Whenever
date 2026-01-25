using Whenver.Base.Models;

namespace Whenver.Base.Entities.ProductOrder;

public class ShippingAddress : BaseEntity<Guid>
{
    public Guid OrderId { get; set; }
    public string AddressLine1 { get; set; }
    public string City { get; set; }
    public string Province { get; set; }
    public string Ward  { get; set; }
    public string ZipCode { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public string ShippingNote { get; set; }
    public virtual Order Order { get; set; }
}