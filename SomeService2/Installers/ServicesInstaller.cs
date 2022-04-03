using Shared.Installers;
using SomeService2.Services;
using SomeService2.Services.Abstract;

namespace SomeService2.Installers;

public class ServicesInstaller : IInstaller
{
	public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
	{
		services.AddScoped<IUserManager, UserManager>();
	}
}