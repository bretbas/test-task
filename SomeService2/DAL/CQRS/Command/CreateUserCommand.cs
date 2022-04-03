using MediatR;

namespace SomeService2.DAL.CQRS.Command;

public class CreateUserCommand : IRequest
{
	public string Name { get; set; }

	public string Surname { get; set; }

	public string MiddleName { get; set; }

	public string PhoneNumber { get; set; }

	public string Email { get; set; }
}