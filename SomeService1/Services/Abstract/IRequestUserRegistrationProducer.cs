using Contracts;

namespace SomeService1.Services.Abstract;

public interface IRequestUserRegistrationProducer
{
	Task Send(ICreateUserMessage createUserMessage);
}