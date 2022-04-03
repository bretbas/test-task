
namespace SomeService2.Additions.Extensions;

public static class IConfigurationExtensions
{
	public static T Get<T>(this IConfiguration configuration, string key) =>
		configuration.GetSection(key).Get<T>();
}