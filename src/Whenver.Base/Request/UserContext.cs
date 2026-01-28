using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Whenver.Base.Request;

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    // Lấy User hiện tại từ HttpContext
    private ClaimsPrincipal? User => httpContextAccessor.HttpContext?.User;
    
    // Lấy UserId từ Claim
    public Guid? UserId
    {
        get
        {
            var id = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return id != null ? Guid.Parse(id) : null;
        }
    }
    
    public string Role => User?.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty;
    public IEnumerable<string> Roles => User?.FindAll(ClaimTypes.Role)?
        .Select(u => u.Value) ?? Enumerable.Empty<string>();
    public bool IsAuthenticated => User?.Identity?.IsAuthenticated ?? false;
    public bool IsSystemAdmin => Roles.Contains("SystemAdmin");

    public bool IsEndUser => Roles.Contains("User");

}