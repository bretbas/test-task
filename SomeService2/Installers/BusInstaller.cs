using MassTransit;
using Shared.Installers;
using Shared.Options;
using SomeService2.Consumers;
using SomeService2.Additions.Extensions;

namespace SomeService2.Installers;

public class BusInstaller : IInstaller
{
	public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
	{
		services.AddMassTransit(opt =>
		{
			var rabbitMqOptions = configuration.Get<RabbitMqOptions>(RabbitMqOptions.RabbitMqSection);
			opt.UsingRabbitMq((context, cfg) =>
			{
				cfg.Host(rabbitMqOptions.Host, rabbitMqOptions.VirtualHost, x => {
					x.Username(rabbitMqOptions.Login);
					x.Password(rabbitMqOptions.Password);
				});

				cfg.ConfigureEndpoints(context);

				cfg.UseJsonSerializer();
			});

			opt.AddConsumer<UserCreateConsumer>();
		});
	}
}