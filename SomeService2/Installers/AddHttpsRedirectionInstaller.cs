using Shared.Installers;

namespace SomeService2.Installers;

public class HttpsRedirectionInstaller : IInstaller
{
	public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
	{
		if (!environment.IsDevelopment())
			services.AddHttpsRedirection(opts =>
			{
				opts.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
				opts.HttpsPort = 443;
			});
		else
			services.AddHttpsRedirection(opts =>
			{
				opts.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
				opts.HttpsPort = 443;
			});
	}
}