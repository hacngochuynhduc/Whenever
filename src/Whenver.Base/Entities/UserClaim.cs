using Microsoft.AspNetCore.Identity;

namespace Whenver.Base.Entities;

public class UserClaim : IdentityUserClaim<Guid>
{
    public User User { get; set; }
}