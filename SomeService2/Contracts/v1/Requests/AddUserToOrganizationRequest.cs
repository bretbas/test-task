
namespace SomeService2.Contracts.v1.Requests;

public class AddUserToOrganizationRequest
{
	public int UserId { get; set; }

	public int OrganizationId { get; set; }
}