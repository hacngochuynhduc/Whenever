using Microsoft.AspNetCore.Identity;

namespace Whenver.Base.Entities;

public class UserLogin : IdentityUserLogin<Guid>
{
    public User User { get; set; }
    
}