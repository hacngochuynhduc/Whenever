using Microsoft.AspNetCore.Identity;

namespace Whenver.Base.Entities;


//User Login này được dùng để phát triển các login google, facebook các loại,..
public class UserLogin : IdentityUserLogin<Guid>
{
    public User User { get; set; }
    
}