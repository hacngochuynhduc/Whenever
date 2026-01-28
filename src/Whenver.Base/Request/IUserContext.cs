namespace Whenver.Base.Request;

public interface IUserContext
{
    Guid? UserId { get; }
    string Role{ get; }
    IEnumerable<string> Roles { get; }
    bool IsAuthenticated { get; }
    bool IsEndUser  { get; }
    bool IsSystemAdmin { get; }
}