using MediatR;
using SomeService2.DAL.Additions.Extensions;
using SomeService2.DAL.CQRS.Query;
using SomeService2.DAL.CQRS.Responses;
using SomeService2.DAL.CQRS.ValueObjects;

namespace SomeService2.DAL.Handlers.Query;

internal class GetUsersHandler : IRequestHandler<GetUsersQuery, Pagination<UserResponse>>
{
	private readonly ApplicationContext _context;

	public GetUsersHandler(ApplicationContext context)
	{
		_context = context ?? throw new ArgumentNullException(nameof(context));
	}

	public async Task<Pagination<UserResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
	{
		var users = await _context.Users
			.Where(x => !request.OrganizationId.HasValue || x.OrganizationId == request.OrganizationId.Value)
			.Select(x => new UserResponse()
			{
				Id = x.Id,
				Name = x.Name,
				Email = x.Email,
				Surname = x.Surname,
				MiddleName = x.MiddleName,
				PhoneNumber = x.PhoneNumber,
				OrganizationId = x.OrganizationId
			})
			.WithPaginationAsync(request.CurrentPage, request.PerPage);

		return users;
	}
}