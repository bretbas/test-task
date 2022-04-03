namespace Contracts;

public interface ICreateUserMessage
{
	string Name { get; set; }

	string Surname { get; set; }

	string MiddleName { get; set; }

	string PhoneNumber { get; set; }

	string Email { get; set; }
}

public class CreateUserMessage : ICreateUserMessage
{
	public string Name { get; set; }

	public string Surname { get; set; }

	public string MiddleName { get; set; }

	public string PhoneNumber { get; set; }

	public string Email { get; set; }
}