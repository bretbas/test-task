using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SomeService2.DAL.Entities.Contracts;

namespace SomeService2.DAL.Additions.Extensions;

internal static class ChangeTrackerExtensions
{
	public static void TrackImplicitTimeBeforeSaveChanges(this ChangeTracker changeTracker)
	{
		foreach(var entityEntry in changeTracker.Entries<ITimeTrackableEntity>())
		{
			switch(entityEntry.State)
			{
				case EntityState.Added:
					entityEntry.Entity.DateCreated = entityEntry.Entity.DateUpdated = DateTime.UtcNow;
					break;
				case EntityState.Modified:
					entityEntry.Entity.DateUpdated = DateTime.UtcNow;
					break;
			}
		}
	}
}