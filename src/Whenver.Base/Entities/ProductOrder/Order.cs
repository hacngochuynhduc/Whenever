using Whenver.Base.Models;

namespace Whenver.Base.Entities.ProductOrder;

public enum OrderStatus
{
    Pending,
    Processing,
    ReadyToShip,
    Shipped,
    Delivered,
    Cancelled
}

public enum PaymentStatus
{
    Unpaid,
    Paid,
    Refunded,
    Failed
}

public enum PaymentMethod
{
    COD,
    BankTransfer
}

public class Order : BaseEntity<Guid>
{
    public Guid? UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderCode { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Unpaid;
    public OrderStatus Status { get; set; }
    public decimal TaxAmount { get; set; } //Total Tax Amount
    public decimal Subtotal { get; set; } //Amount Exclude Tax
    public decimal ShippingFee { get; set; }
    public decimal TotalAmount { get; set; } //Final Amount: (Subtotal + TaxAmount + ShippingFee)
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public virtual ShippingAddress ShippingAddress { get; set; }
    public virtual PersonalizationUser User { get; set; }
}