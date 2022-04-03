using SomeService2.DAL.CQRS.ValueObjects;
using SomeService2.Services.Models;

namespace SomeService2.Services.Abstract;

public interface IUserManager
{
	Task CreateUserAsync(CreateUserModel createUserModel);

	Task AddUserToOrganizationAsync(int userId, int organizationId);

	Task<Pagination<UserModel>> GetUsersByOrganizationIdAsync(int organizationId, int currentPage = 1, int perPage = 10);
}