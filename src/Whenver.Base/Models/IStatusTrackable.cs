namespace Whenver.Base.Models;

public interface IStatusTrackable<T>
{
 bool IsActive { get; set; }
}