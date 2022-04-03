using System.Net;

namespace Shared.Infrastructure.ApiResponses;

public class ApiForbidResponse : ApiResponse
{
	public ApiForbidResponse(string message = null)
		: base(HttpStatusCode.Forbidden, message)
	{
	}
}