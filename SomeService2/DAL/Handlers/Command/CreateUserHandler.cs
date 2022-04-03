
using MediatR;
using SomeService2.DAL.CQRS.Command;
using SomeService2.DAL.Entities;

namespace SomeService2.DAL.Handlers.Command;

internal class CreateUserHandler : IRequestHandler<CreateUserCommand>
{
	private readonly ApplicationContext _context;

	public CreateUserHandler(ApplicationContext context)
	{
		_context = context ?? throw new ArgumentNullException(nameof(context));
	}

	public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		var user = new User()
		{
			Name = request.Name,
			Email = request.Email,
			Surname = request.Surname,
			MiddleName = request.MiddleName,
			PhoneNumber = request.PhoneNumber
		};
		await _context.AddAsync(user);
		await _context.SaveChangesAsync(cancellationToken);

		return Unit.Value;
	}
}