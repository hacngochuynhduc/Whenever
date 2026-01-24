using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Whenver.Base.Models;

/// <summary>
/// Tạo 1 interface IEntity để generate ID [Key] Đánh dấu Primary Key
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IEntity<T>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    T Id { get; set; }
}