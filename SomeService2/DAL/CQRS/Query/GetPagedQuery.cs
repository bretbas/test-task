using MediatR;
using SomeService2.DAL.CQRS.ValueObjects;

namespace SomeService2.DAL.CQRS.Query;

public class GetPagedQuery<T> : IRequest<Pagination<T>>
{
	public int CurrentPage { get; set; }

	public int PerPage { get; set; }
}