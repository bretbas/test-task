using MassTransit;
using Serilog;
using Shared.Installers;
using Shared.Options;
using SomeService1.Additions.Extensions;

namespace SomeService1.Installers;

public class BusInstaller : IInstaller
{
	public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
	{
		services.AddMassTransit(opt =>
		{
			var rabbitMqOptions = configuration.Get<RabbitMqOptions>(RabbitMqOptions.RabbitMqSection);


			opt.UsingRabbitMq((context, cfg) =>
			{
				cfg.Host("rabbitmq", 5672, "/", x => {
					x.Username(rabbitMqOptions.Login);
					x.Password(rabbitMqOptions.Password);
				});

				cfg.ConfigureEndpoints(context);

				cfg.UseJsonSerializer();
			});

		});
	}
}