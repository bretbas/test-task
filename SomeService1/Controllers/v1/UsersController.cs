using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using SomeService1.Contracts.v1;
using SomeService1.Contracts.v1.Requests;
using SomeService1.Controllers.Abstract;
using SomeService1.Services.Abstract;

namespace SomeService1.Controllers.v1;

[Route(ApiRoutes.Users)]
public class UsersController : ApiController
{
	private readonly IRequestUserRegistrationProducer _requestUserRegistrationProducer;
	private readonly Serilog.ILogger _logger = Log.ForContext<UsersController>();

	public UsersController(IRequestUserRegistrationProducer requestUserRegistrationProducer)
	{
		_requestUserRegistrationProducer = requestUserRegistrationProducer ?? throw new ArgumentNullException(nameof(requestUserRegistrationProducer));
	}

	[HttpPost]
	public async Task<IActionResult> CreateRequestForUserRegistrationAsync(UserRequest request)
	{
		if (request == null) throw new ArgumentNullException(nameof(request));

		await _requestUserRegistrationProducer.Send(new CreateUserMessage
		{
			Name = request.Name,
			Email = request.Email,
			Surname = request.Surname,
			MiddleName = request.MiddleName,
			PhoneNumber = request.PhoneNumber
		});

		_logger.Information(
			"REQUEST FOR USER REGISTRATION: Name: {0}; Surname: {1}; Middlename: {2}; PhoneNumber: {3}; Email: {4}",
			request.Name,
			request.Surname,
			request.MiddleName,
			request.PhoneNumber,
			request.Email);

		return OkWithMessage("The request is sent");
	}
}
