using Serilog;
using Serilog.Events;
using Shared.Installers;
using Shared.Middlewares;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

var application = await WebApplicationHelper.CreateWebApplicationBuilderAsync(args);
application.Run();

public partial class Program { }

static class WebApplicationHelper
{
    public static Task<WebApplication> CreateWebApplicationBuilderAsync(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Устанавливаем все сервисы из инсталлеров
        builder.Services.InstallServicesInAssembly(builder.Configuration, builder.Environment);

        builder.WebHost.UseUrls("http://0.0.0.0:40071");

        var app = builder.Build();
        app.Configure();

        return Task.FromResult(app);
    }

    private static void Configure(this IApplicationBuilder app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(opt =>
        {
            opt.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            opt.RoutePrefix = "api";
        });

        app.UseMiddleware<ExceptionMiddleware>();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}