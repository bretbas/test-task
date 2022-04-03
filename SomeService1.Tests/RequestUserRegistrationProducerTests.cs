using System.Threading;
using System.Threading.Tasks;
using Contracts;
using MassTransit;
using Moq;
using NUnit.Framework;
using SomeService1.Services;

namespace SomeService1.Tests;

public class RequestUserRegistrationProducerTests
{
	[Test]
	public async Task CheckHowSendUserRegistrationDataTest()
	{
		var testMessage = new CreateUserMessage()
		{
			Name = "TestName",
			Surname = "TestSurname",
			PhoneNumber = "+79991234433"
		};
		var assertMessage = (ICreateUserMessage)null;

		var publishEndpointMock = new Mock<IPublishEndpoint>();
		publishEndpointMock
			.Setup(x => x.Publish(It.IsAny<ICreateUserMessage>(), It.IsAny<CancellationToken>()))
			.Callback((ICreateUserMessage message, CancellationToken token) =>
			{
				assertMessage = message;
			})
			.Returns(() => Task.CompletedTask);

		var requestUserRegistrationProducer = new RequestUserRegistrationProducer(publishEndpointMock.Object);
		await requestUserRegistrationProducer.Send(testMessage);

		Assert.AreEqual(testMessage, assertMessage);
	}
}