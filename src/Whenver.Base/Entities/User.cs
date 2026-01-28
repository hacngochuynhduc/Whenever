using Microsoft.AspNetCore.Identity;
using Whenver.Base.Models;

namespace Whenver.Base.Entities;


public enum UserType
{
    System = 0,
    EndUser =1
}

/// <summary>
/// ICollection là interface nâng cấp của IEnumerable cho phép duyệt qua các phần tử và thay đổi chúng như .add, .remove, .count,..
/// Nó là tiêu chuẩn trong quan hệ của EF Core Navigation Property (Quan hệ giữa các bảng).
/// Nếu muốn đọc dữ liệu thì dùng IEnumerable , muốn thêm xóa sửa thì ICollection   
/// </summary>
public class User : BaseIdentityUser
{
    public UserType UserType { get; set; }
    public string? FirstName  { get; set; }
    public string? LastName  { get; set; }
    public string? AvatarUrl  { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public ICollection<UserClaim> UserClaims { get; set; } = new List<UserClaim>(); 
    public ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();
    public ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>(); // lưu token (refresh token, resetpassword,..)
    
    
}

public class BaseIdentityUser : IdentityUser<Guid>, IEntity<Guid>, IStatusTrackable<Guid>
{
    
    //Khai báo IndentityUser (package có sẵn của .Net nên IEntity không cần phải khai báo T Id)
    public Guid? UpdateBy { get; set; }
    public bool? IsDeleted {get;set;} = false;
    public DateTime? CreatedDate {get;set;} = DateTime.UtcNow;
    public DateTime? UpdatedDate {get;set;}
    public bool IsActive { get; set; } = false;
}