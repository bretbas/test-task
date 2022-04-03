using System.Net;

namespace Shared.Infrastructure.ApiResponses;

public class ApiNotFoundResponse : ApiResponse
{
	public ApiNotFoundResponse(string message = null)
		: base(HttpStatusCode.NotFound, message)
	{
	}
}