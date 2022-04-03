using MediatR;

namespace SomeService2.DAL.CQRS.Command;

public class UpdateUserOrganizationCommand : IRequest
{
	public int UserId { get; set; }

	public int OrganizationId { get; set; }
}