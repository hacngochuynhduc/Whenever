using Microsoft.AspNetCore.Identity;

namespace Whenver.Base.Entities;

public class UserToken : IdentityUserToken<Guid>
{
    public User User { get; set; }
    public DateTime Expires { get; set; } //Token thì phải có expire
    public Guid Id { get; set; }
}