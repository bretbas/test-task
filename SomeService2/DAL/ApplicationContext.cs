using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SomeService2.DAL.Additions.Extensions;
using SomeService2.DAL.Entities;

namespace SomeService2.DAL;

public class ApplicationContext : DbContext
{
	public IQueryable<User> Users => Set<User>();

	public IQueryable<Organization> Organizations => Set<Organization>();

	public ApplicationContext(DbContextOptions options) : base(options)
	{ }

	public new Task SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		return base.SaveChangesAsync(cancellationToken);
	}

	public override int SaveChanges()
	{
		BeforeSaveChanges();
		return base.SaveChanges();
	}

	public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
	{
		BeforeSaveChanges();
		return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
	}

	protected virtual void BeforeSaveChanges()
	{
		ChangeTracker.TrackImplicitTimeBeforeSaveChanges();
	}

	public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
	{
		await Set<TEntity>().AddAsync(entity);
	}

	public Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
		where TEntity : class
	{
		return Set<TEntity>().AddRangeAsync(entities, cancellationToken);
	}

	protected virtual void AfterOnModelCreating(ModelBuilder builder)
	{
		builder.Entity<User>().ToTable("users");
		builder.Entity<Organization>().ToTable("organizations");
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		base.OnModelCreating(builder);

		AfterOnModelCreating(builder);
	}
}