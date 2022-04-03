using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Additions.Extensions;

namespace Shared.Installers;

public static class IServiceCollectionExtensions
{
    public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        var installers = Assembly.GetCallingAssembly().ExportedTypes
            .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract && !x.IsGenericType && x.HasDefaultConstructor())
            .Select(Activator.CreateInstance)
            .Cast<IInstaller>()
            .ToList();

        installers.ForEach(installer => installer.InstallServices(services, configuration, environment));
    }
}