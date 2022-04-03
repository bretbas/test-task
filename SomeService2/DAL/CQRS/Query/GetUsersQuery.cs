using SomeService2.DAL.CQRS.Responses;

namespace SomeService2.DAL.CQRS.Query;

public class GetUsersQuery : GetPagedQuery<UserResponse>
{
	public int? OrganizationId { get; set; }
}