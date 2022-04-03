using System.Net;

namespace Shared.Infrastructure.ApiResponses;

public class ApiInternalServerErrorResponse : ApiResponse
{
	public ApiInternalServerErrorResponse(string message = null)
		: base(HttpStatusCode.InternalServerError, message)
	{
	}
}