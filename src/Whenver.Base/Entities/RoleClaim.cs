using Microsoft.AspNetCore.Identity;
using Whenver.Base.Models;

namespace Whenver.Base.Entities;
/// <summary>
/// Cần Role Claim để định nghĩa quyền cụ thể cho từng Role
/// </summary>
public class RoleClaim : IdentityRoleClaim<Guid>
{
    public Role Role { get; set; }
}
