using Shared.Installers;

namespace SomeService2.Installers;

public class MappingInstaller : IInstaller
{
	public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
	{
		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
	}
}