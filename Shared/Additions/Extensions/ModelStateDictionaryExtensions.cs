using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Shared.Additions.Extensions;

public static class ModelStateDictionaryExtensions
{
	public static void AddErrors(this ModelStateDictionary source, IdentityResult identityResult) =>
		identityResult.Errors.ForEach(x => source.TryAddModelError(x.Code, x.Description));

	public static void AddError(this ModelStateDictionary source, string code, string description) =>
		source.TryAddModelError(code, description);

	public static IDictionary<string, IEnumerable<string>> ToDictionary(this ModelStateDictionary source) =>
		source.ToDictionary(
			x => x.Key,
			x => x.Value.Errors.Select(e => e.ErrorMessage));

	public static IList<string> ToList(this ModelStateDictionary source) =>
		source.Values
			.SelectMany(x => x.Errors)
			.Select(x => x.ErrorMessage)
			.ToList();
}