using Whenver.Base.Models;

namespace Whenver.Base.Entities;

public class PersonalizationUser : BaseEntity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string AvatarUrl { get; set; }
    public string PhoneNumber { get; set; }
    public string StressAddress  { get; set; }
    public string Province { get; set; }
    public string Ward { get; set; }
    public DateTime? RegistrationDate { get; set; }

    public DateTime? LastLogin { get; set; }
    public DateTime? FirstLogin { get; set; }
    
    
    
}