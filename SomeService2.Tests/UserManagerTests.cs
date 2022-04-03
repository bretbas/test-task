using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using NUnit.Framework;
using SomeService2.DAL.CQRS.Command;
using SomeService2.Services;
using SomeService2.Services.Models;

namespace SomeService2.Tests;

public class UserManagerTests
{
	[SetUp]
	public void Setup()
	{
	}

	[Test]
	public async Task CreateUserTests()
	{
		CreateUserCommand assertCreateUserCommand = null;

		var mediatorMock = new Mock<IMediator>();
		mediatorMock
			.Setup(x => x.Send(It.IsAny<IRequest<Unit>>(), It.IsAny<CancellationToken>()))
			.Callback((IRequest<Unit> request, CancellationToken token) =>
			{
				if(request is CreateUserCommand createUserCommand)
					assertCreateUserCommand = createUserCommand;
			})
			.Returns(() => Task.FromResult(Unit.Value));

		var userManager = new UserManager(mediatorMock.Object);
		await userManager.CreateUserAsync(new CreateUserModel()
		{
			Name = "TestName",
			Surname = "TestSurname",
			PhoneNumber = "+79991234433"
		});

		Assert.NotNull(assertCreateUserCommand);
		Assert.AreEqual("TestName", assertCreateUserCommand.Name);
		Assert.AreEqual("TestSurname", assertCreateUserCommand.Surname);
		Assert.AreEqual("+79991234433", assertCreateUserCommand.PhoneNumber);
	}
}