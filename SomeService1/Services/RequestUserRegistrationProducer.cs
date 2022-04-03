using Contracts;
using MassTransit;
using SomeService1.Services.Abstract;

namespace SomeService1.Services;

internal class RequestUserRegistrationProducer : IRequestUserRegistrationProducer
{
	private readonly IPublishEndpoint _publishEndpoint;

	public RequestUserRegistrationProducer(IPublishEndpoint publishEndpoint)
	{
		_publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
	}

	public async Task Send(ICreateUserMessage createUserMessage)
	{
		await _publishEndpoint.Publish(createUserMessage);
	}
}