using Microsoft.AspNetCore.Identity;
using Whenver.Base.Models;

namespace Whenver.Base.Entities;

public class Role : IdentityRole<Guid>, IEntity<Guid>
{
    public string? Description { get; set; }
    public string? Slug  { get; set; }
    public ICollection<RoleClaim> RoleClaims { get; set; } //Role có nhiều quyền
    public ICollection<UserRole> UserRoles { get; set; } = new  List<UserRole>(); //1 Role thì có thể có nhiều User
}