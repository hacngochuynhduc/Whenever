using Microsoft.AspNetCore.Identity;

namespace Whenver.Base.Entities;
/// <summary>
/// Dùng virtual để tự động query khi gọi :vd userRole.User
/// </summary>
public class UserRole : IdentityUserRole<Guid>
{
    public virtual User User { get; set; }
    public virtual Role  Role { get; set; }
}