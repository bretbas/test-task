using Shared.Additions.FluentValidators.Options.Enums;

namespace Shared.Additions.FluentValidators.Options;

public class PhoneNumberOptions
{
    public string CountryCode { get; set; }

    public PhoneNumberType PhoneType { get; set; } = PhoneNumberType.All;

    public PhoneNumberFormat PhoneFormat { get; set; } = PhoneNumberFormat.E164;
}