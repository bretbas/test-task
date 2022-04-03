using FluentValidation;
using Shared.Additions.FluentValidators;
using Shared.Additions.FluentValidators.Options;

namespace Shared.Additions.Extensions;

public static class FluentValidationExtensions
{
	public static IRuleBuilderOptions<T, string> IsPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder) =>
		ruleBuilder.SetValidator(new PhoneNumberValidator<T>());

	public static IRuleBuilderOptions<T, string> IsPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder, Action<PhoneNumberOptions> configure) =>
		ruleBuilder.SetValidator(new PhoneNumberValidator<T>(configure));

	public static IRuleBuilderOptions<T, TProperty> OneOf<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, params TProperty[] validOptions) =>
		ruleBuilder.Must(validOptions.Contains);

	public static IRuleBuilderOptions<T, string> IsLetterOrDigit<T>(this IRuleBuilder<T, string> ruleBuilder, params char[] allowedSymbols) =>
		ruleBuilder.Must(x => x.All(y => char.IsLetterOrDigit(y) || allowedSymbols.Contains(y)));

	public static IRuleBuilderOptions<T, string> IsLetter<T>(this IRuleBuilder<T, string> ruleBuilder, params char[] allowedSymbols) =>
		ruleBuilder.Must(x => x.All(y => char.IsLetter(y) || allowedSymbols.Contains(y)));

	public static IRuleBuilderOptions<T, string> IsDigit<T>(this IRuleBuilder<T, string> ruleBuilder, params char[] allowedSymbols) =>
		ruleBuilder.Must(x => x.All(y => char.IsDigit(y) || allowedSymbols.Contains(y)));

	public static IRuleBuilderOptions<T, string> Contains<T>(this IRuleBuilder<T, string> ruleBuilder, string match) =>
		ruleBuilder.Must(x => x.Contains(match));

	public static IRuleBuilderOptions<T, string> Url<T>(this IRuleBuilder<T, string> ruleBuilder) =>
		ruleBuilder.Must(x => Uri.TryCreate(x, UriKind.Absolute, out var url) && (url.Scheme == Uri.UriSchemeHttp || url.Scheme == Uri.UriSchemeHttps));
}