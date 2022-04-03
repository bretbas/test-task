using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Shared.Infrastructure.ApiResponses;
using Shared.Installers;

namespace SomeService1.Installers;

public class RestInstaller : IInstaller
{
	public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
	{
		services.AddControllers()
			.AddNewtonsoftJson(opt =>
			{
				opt.SerializerSettings.Converters.Add(new StringEnumConverter());
				opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
			})
			.ConfigureApiBehaviorOptions(opt =>
			{
				opt.InvalidModelStateResponseFactory = actionContext =>
					new BadRequestObjectResult(
						new ApiBadRequestResponse(actionContext.ModelState, "The validation fails"));
			})
			.AddFluentValidation(opt =>
			{
				opt.RegisterValidatorsFromAssemblyContaining<RestInstaller>();
				opt.ImplicitlyValidateChildProperties = true;
			});
	}
}