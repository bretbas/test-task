using MediatR;
using Shared;
using SomeService2.DAL.CQRS.Command;
using SomeService2.DAL.Entities;
using Z.EntityFramework.Plus;

namespace SomeService2.DAL.Handlers.Command;

internal class UpdateUserOrganizationHandler : IRequestHandler<UpdateUserOrganizationCommand>
{
	private readonly ApplicationContext _context;

	public UpdateUserOrganizationHandler(ApplicationContext context)
	{
		_context = context ?? throw new ArgumentNullException(nameof(context));
	}

	public async Task<Unit> Handle(UpdateUserOrganizationCommand request, CancellationToken cancellationToken)
	{
		var rowAffected = await _context.Users
			.Where(x => x.Id == request.UserId)
			.UpdateAsync(x => new User()
			{
				OrganizationId = request.OrganizationId
			}, cancellationToken: cancellationToken);
		if (rowAffected == 0)
			throw new NotFoundException($"The user with id {request.UserId} is not found");

		return Unit.Value;
	}
}