namespace SomeService2.DAL.CQRS.Responses;

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