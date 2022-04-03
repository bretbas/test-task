using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SomeService2.Contracts.v1;
using SomeService2.Contracts.v1.Requests;
using SomeService2.Contracts.v1.Responses;
using SomeService2.Controllers.Abstract;
using SomeService2.DAL.CQRS.ValueObjects;
using SomeService2.Services.Abstract;

namespace SomeService2.Controllers.v1;

[Route(ApiRoutes.Users)]
public class UsersController : ApiController
{
	private readonly IUserManager _userManager;
	private readonly IMapper _mapper;

	public UsersController(IUserManager userManager, IMapper mapper)
	{
		_userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
		_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
	}

	[HttpPost(ApiRoutes.UserApi.ByOrganizationId)]
	public async Task<IActionResult> GetUsersAsync(int organizationId, GetUsersRequest request)
	{
		if (request == null) throw new ArgumentNullException(nameof(request));

		var users = await _userManager.GetUsersByOrganizationIdAsync(organizationId, request.CurrentPage, request.PerPage);
		return OkWithResult(_mapper.Map<Pagination<UserResponse>>(users));
	}

	[HttpPost]
	public async Task<IActionResult> AddUserToOrganizationAsync(AddUserToOrganizationRequest request)
	{
		if (request == null) throw new ArgumentNullException(nameof(request));

		await _userManager.AddUserToOrganizationAsync(request.UserId, request.OrganizationId);
		return OkWithMessage("The user added to the organization");
	}
}
