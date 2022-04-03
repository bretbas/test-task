using FluentValidation;
using FluentValidation.Validators;
using PhoneNumbers;
using Shared.Additions.FluentValidators.Options;

namespace Shared.Additions.FluentValidators;

internal class PhoneNumberValidator<T> : PropertyValidator<T, string>
{
	private readonly PhoneNumberUtil _phoneNumberUtil = null;

	private readonly PhoneNumberOptions _option = null;

	protected override string GetDefaultMessageTemplate(string errorCode) => "Phone number is incorrect";

	public override string Name => nameof(PhoneNumberValidator<T>);

	public PhoneNumberValidator(Action<PhoneNumberOptions> configureOption)
	{
		_phoneNumberUtil = PhoneNumberUtil.GetInstance();
		_option = new PhoneNumberOptions();
		configureOption(_option);
	}

	public PhoneNumberValidator()
	{
		_phoneNumberUtil = PhoneNumberUtil.GetInstance();
		_option = new PhoneNumberOptions();
	}

	public override bool IsValid(ValidationContext<T> context, string value)
	{
		var phoneNumber = value;
		if(string.IsNullOrEmpty(phoneNumber))
		{
			context.AddFailure("ValidationMessage", $"The property {context.PropertyName} is empty");
			return false;
		}

		try
		{
			var phone = _phoneNumberUtil.Parse(phoneNumber, null);

			if (!_phoneNumberUtil.IsValidNumber(phone))
			{
				context.AddFailure("ValidationMessage", "Wrong phone number. Make sure that phone number guaranteed to start with a '+' followed by the country calling code");
				return false;
			}

			if (!string.IsNullOrEmpty(_option.CountryCode) && !_phoneNumberUtil.IsValidNumberForRegion(phone, _option.CountryCode))
			{
				context.AddFailure("ValidationMessage", "Country code is not supported");
				return false;
			}

			var numberType = _phoneNumberUtil.GetNumberType(phone);
			string phoneNumberType = numberType.ToString();
			switch (_option.PhoneType)
			{
				case Options.Enums.PhoneNumberType.FixedLine:
				{
					if(phoneNumberType != "FIXED_LINE")
					{
						context.AddFailure("ValidationMessage", "The phone number type must be fixed line");
						return false;
					}
				}
					break;
				case Options.Enums.PhoneNumberType.Mobile:
				{
					if(phoneNumberType != "MOBILE")
					{
						context.AddFailure("ValidationMessage", "The phone number type must be mobile");
						return false;
					}
				}
					break;
			}

			switch(_option.PhoneFormat)
			{
				case Options.Enums.PhoneNumberFormat.E164:
				{
					var normalizePhoneNumber = _phoneNumberUtil.Format(phone, PhoneNumbers.PhoneNumberFormat.E164);
					if(normalizePhoneNumber != phoneNumber)
					{
						context.AddFailure("ValidationMessage", "The phone number format must be E164");
						return false;
					}
				}
					break;
				case Options.Enums.PhoneNumberFormat.International:
				{
					var normalizePhoneNumber = _phoneNumberUtil.Format(phone, PhoneNumbers.PhoneNumberFormat.INTERNATIONAL);
					if(normalizePhoneNumber != phoneNumber)
					{
						context.AddFailure("ValidationMessage", "The phone number format must be International");
						return false;
					}
				}
					break;
				case Options.Enums.PhoneNumberFormat.National:
				{
					var normalizePhoneNumber = _phoneNumberUtil.Format(phone, PhoneNumbers.PhoneNumberFormat.NATIONAL);
					if (normalizePhoneNumber != phoneNumber)
					{
						context.AddFailure("ValidationMessage", "The phone number format must be National");
						return false;
					}
				}
					break;
				case Options.Enums.PhoneNumberFormat.RFC3966:
				{
					var normalizePhoneNumber = _phoneNumberUtil.Format(phone, PhoneNumbers.PhoneNumberFormat.RFC3966);
					if (normalizePhoneNumber != phoneNumber)
					{
						context.AddFailure("ValidationMessage", "The phone number format must be RFC3966");
						return false;
					}
				}
					break;
			}

			return true;
		}
		catch (NumberParseException)
		{
			context.AddFailure("Wrong phone number. Make sure that phone number guaranteed to start with a '+' followed by the country calling code");
			return false;
		}
	}
}