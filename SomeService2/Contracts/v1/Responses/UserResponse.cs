namespace SomeService2.Contracts.v1.Responses;

public class UserResponse
{
	public int Id { get; set; }

	public string Name { get; set; }

	public string Surname { get; set; }

	public string MiddleName { get; set; }

	public string PhoneNumber { get; set; }

	public string Email { get; set; }

	public int? OrganizationId { get; set; }
}