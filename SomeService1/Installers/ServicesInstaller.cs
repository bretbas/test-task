using Shared.Installers;
using SomeService1.Services;
using SomeService1.Services.Abstract;

namespace SomeService1.Installers;

public class ServicesInstaller : IInstaller
{
	public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
	{
		services.AddScoped<IRequestUserRegistrationProducer, RequestUserRegistrationProducer>();
	}
}