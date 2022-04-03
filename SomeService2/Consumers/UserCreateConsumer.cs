using Contracts;
using MassTransit;
using Serilog;
using SomeService2.Services.Abstract;
using SomeService2.Services.Models;

namespace SomeService2.Consumers;

public class UserCreateConsumer : IConsumer<ICreateUserMessage>
{
	private readonly IUserManager _userManager;
	private readonly Serilog.ILogger _logger = Log.ForContext<UserCreateConsumer>();

	public UserCreateConsumer(IUserManager userManager)
	{
		_userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
	}

	public async Task Consume(ConsumeContext<ICreateUserMessage> context)
	{
		var message = context.Message;
		await _userManager.CreateUserAsync(new CreateUserModel()
		{
			Email = message.Email,
			Name = message.Name,
			Surname = message.Surname,
			MiddleName = message.MiddleName,
			PhoneNumber = message.PhoneNumber
		});

		_logger.Information(
			"USER CREATED: Name: {0}; Surname: {1}; Middlename: {2}; PhoneNumber: {3}; Email: {4}",
			message.Name,
			message.Surname,
			message.MiddleName,
			message.PhoneNumber,
			message.Email);
	}
}