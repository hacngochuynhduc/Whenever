using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Whenver.Base.Constants;

namespace Whenver.Base.Helpers;

public class ApplicationUser : ApplicationUserBase
{
    private readonly Guid _userId;

    public ApplicationUser(HttpContext httpContext) : base(httpContext?.User ??
                                                           new ClaimsPrincipal(new ClaimsIdentity()))
    {
        if (httpContext == null || !IsHttpContextAvailable())
            httpContext = new DefaultHttpContext();
        else
            Guid.TryParse(GetClaim(ClaimTypes.NameIdentifier), out _userId);
    }

    public Guid UserId => _userId;

    public string Email => GetClaim(ClaimTypes.Email);
    public bool IsAdmin => HasRole(RoleConstant.Administrator);
    public string Role => GetClaim(ClaimTypes.Role);
    public bool IsNormalUser => HasRole(RoleConstant.NormalUser);
    public int TimezoneOffset { get; private set; }

    private bool IsHttpContextAvailable()
    {
        // Check if we are in an HTTP context (for example, to see if Hangfire is running)
        var context = new HttpContextAccessor();
        return context.HttpContext != null;
    }
}