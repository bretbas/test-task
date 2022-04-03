using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shared.Installers;
using SomeService2.DAL;
using SomeService2.DAL.CQRS.Command;
using SomeService2.DAL.CQRS.Query;
using SomeService2.DAL.CQRS.Responses;
using SomeService2.DAL.CQRS.ValueObjects;
using SomeService2.DAL.Handlers.Command;
using SomeService2.DAL.Handlers.Query;

namespace SomeService2.Installers;

public class DbInstaller : IInstaller
{
	public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
	{
		services.AddMediatR(opt => opt.AsScoped(), Assembly.GetExecutingAssembly());

		var connectionString = configuration.GetConnectionString("MySqlConnectionString");

		var logger = Log.ForContext<DbInstaller>();
		logger.Error(connectionString);

		services.AddDbContext<ApplicationContext>(opt =>
		{
			opt.UseNpgsql(connectionString);
			opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
		});

		// Queries
		services
			.AddScoped<IRequestHandler<GetUsersQuery, Pagination<UserResponse>>, GetUsersHandler>();

		// Commands
		services
			.AddScoped<IRequestHandler<CreateUserCommand, Unit>, CreateUserHandler>()
			.AddScoped<IRequestHandler<UpdateUserOrganizationCommand, Unit>, UpdateUserOrganizationHandler>();
	}
}