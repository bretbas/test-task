using AutoMapper;
using SomeService2.Contracts.v1.Responses;
using SomeService2.DAL.CQRS.ValueObjects;
using SomeService2.Mappings.Converters;
using SomeService2.Services.Models;

namespace SomeService2.Mappings.v1;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap(typeof(Pagination<>), typeof(Pagination<>))
			.ConvertUsing(typeof(PaginationConverter<,>));

		CreateMap<UserModel, UserResponse>();
	}
}