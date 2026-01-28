namespace Whenver.Base.Models;


/// <summary>
///  Tạo abstract Class Basse Entity để dùng chung cho tất cả entity khi build database
/// <T> (Generic) cho phép có nhiều kiểu BaseEntity khác nhau như int, guid, long,..
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BaseEntity<T> : IEntity<T>, IStatusTrackable<T>
{
    public Guid? UpdateBy { get; set; }
    public bool IsDeleted { get; set; } = false;

    public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
    
    public T Id { get; set; }
    public bool IsActive { get; set; }

}