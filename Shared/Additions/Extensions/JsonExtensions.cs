using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Shared.Additions.Extensions;

public static class JsonExtensions
{
	public static string ToJson(this object source)
		=> JsonConvert.SerializeObject(
			source,
			new JsonSerializerSettings()
			{
				NullValueHandling = NullValueHandling.Include,
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			});

	public static T FromJson<T>(this string source) =>
		JsonConvert.DeserializeObject<T>(source);

	public static T FromJson<T>(this JToken source, params JsonConverter[] converters) =>
		JsonConvert.DeserializeObject<T>(
			source.ToString(),
			new JsonSerializerSettings()
			{
				Converters = converters,
				DateTimeZoneHandling = DateTimeZoneHandling.Utc
			});

	public static JObject ToJsonObject(this string source, params JsonConverter[] converters) =>
		(JObject)JsonConvert.DeserializeObject(
			source.ToString(),
			new JsonSerializerSettings()
			{
				Converters = converters,
				DateTimeZoneHandling = DateTimeZoneHandling.Utc
			});

	public static JArray ToJsonArray(this string source) =>
		(JArray)JsonConvert.DeserializeObject(source);

	public static T ToRequiredObject<T>(this JToken @this)
	{
		var result = @this.ToObject<T>();
		if (result == null)
			throw new SerializationException($"The json doesn't deserialize to ${typeof(T).Name}");

		return result;
	}
}