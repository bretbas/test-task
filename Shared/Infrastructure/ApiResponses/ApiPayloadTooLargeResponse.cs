using System.Net;

namespace Shared.Infrastructure.ApiResponses;

public class ApiPayloadTooLargeResponse : ApiResponse
{
	public ApiPayloadTooLargeResponse(string message = null)
		: base(HttpStatusCode.RequestEntityTooLarge, message)
	{
	}
}