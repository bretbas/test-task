using Microsoft.OpenApi.Models;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Shared.Installers;

namespace SomeService1.Installers;

public class SwaggerInstaller : IInstaller
{
	public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
	{
		services.AddSwaggerGen(opt =>
		{
			opt.DescribeAllParametersInCamelCase();

			opt.SwaggerDoc("v1", new OpenApiInfo
			{
				Title = "TestTask API",
				Version = "v1",
				Contact = new OpenApiContact
				{
					Name = "Максим Шилов",
					Email = "bretbas@mail.ru",
					Url = new Uri("https://t.me/Bretbas"),
				}
			});
		});

		// Добавляем описание правил валидации
		services.AddFluentValidationRulesToSwagger();

		// Добавляем поддержку Newtonsoft для сваггера
		services.AddSwaggerGenNewtonsoftSupport();
	}
}