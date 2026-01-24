using Whenver.Base.Models;

namespace Whenver.Base.Entities;

public class Product : BaseEntity<Guid>
{
    public Guid CategoryId  { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }      // Giá bán (ĐÃ bao gồm VAT) - Customer thấy giá này 
    public decimal PriceExcludingTax { get; set; }  // Giá chưa VAT - Dashboard hiển thị
    public decimal VATAmount { get; set; }          // Số tiền VAT = PriceExcludingVAT * 10%
    public decimal VATRate { get; set; }            // Thuế suất VAT (default: 0.10 = 10%)
    public decimal Weight { get; set; }
    public string? Details { get; set; }
    public string? Slug { get; set; }
    public virtual Category Category { get; set; }
}