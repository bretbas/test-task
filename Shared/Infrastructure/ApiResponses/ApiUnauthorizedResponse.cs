using System.Net;

namespace Shared.Infrastructure.ApiResponses;

public class ApiUnauthorizedResponse : ApiResponse
{
	public IEnumerable<string> Errors { get; }

	public ApiUnauthorizedResponse(string message, params string[] errors)
		: base(HttpStatusCode.Unauthorized, message)
	{
		Errors = errors.Any() ? errors : null;
	}
}