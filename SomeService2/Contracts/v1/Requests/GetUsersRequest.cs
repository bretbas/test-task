namespace SomeService2.Contracts.v1.Requests;

public class GetUsersRequest
{
	public int CurrentPage { get; set; } = 1;

	public int PerPage { get; set; } = 10;
}