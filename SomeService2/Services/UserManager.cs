using MediatR;
using SomeService2.DAL.CQRS.Command;
using SomeService2.DAL.CQRS.Query;
using SomeService2.DAL.CQRS.ValueObjects;
using SomeService2.Services.Abstract;
using SomeService2.Services.Models;

namespace SomeService2.Services;

internal class UserManager : IUserManager
{
	private readonly IMediator _mediator;

	public UserManager(IMediator mediator)
	{
		_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
	}


	public async Task CreateUserAsync(CreateUserModel createUserModel)
	{
		// TODO Тут может быть логика

		await _mediator.Send(new CreateUserCommand()
		{
			Name = createUserModel.Name,
			Surname = createUserModel.Surname,
			Email = createUserModel.Email,
			MiddleName = createUserModel.MiddleName,
			PhoneNumber = createUserModel.PhoneNumber
		});
	}

	public async Task AddUserToOrganizationAsync(int userId, int organizationId)
	{
		await _mediator.Send(new UpdateUserOrganizationCommand()
		{
			UserId = userId,
			OrganizationId = organizationId
		});
	}

	public async Task<Pagination<UserModel>> GetUsersByOrganizationIdAsync(int organizationId, int currentPage = 1, int perPage = 10)
	{
		var pagination = await _mediator.Send(new GetUsersQuery()
		{
			OrganizationId = organizationId,
			CurrentPage = currentPage,
			PerPage = perPage
		});

		return new Pagination<UserModel>()
		{
			Entities = pagination.Entities
				.Select(x => new UserModel()
				{
					Id = x.Id,
					Name = x.Name,
					Email = x.Email,
					Surname = x.Surname,
					MiddleName = x.MiddleName,
					PhoneNumber = x.PhoneNumber,
					OrganizationId = x.OrganizationId
				})
				.ToList(),
			CurrentPage = pagination.CurrentPage,
			PerPage = pagination.PerPage,
			TotalEntities = pagination.TotalEntities
		};
	}
}