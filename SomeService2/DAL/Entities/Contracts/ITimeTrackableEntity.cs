
namespace SomeService2.DAL.Entities.Contracts;

public interface ITimeTrackableEntity
{
	DateTime DateCreated { get; set; }

	DateTime DateUpdated { get; set; }
}