using Whenver.Base.Models;

namespace Whenver.Base.Entities;

public class PersonalizationUser : BaseEntity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    
}