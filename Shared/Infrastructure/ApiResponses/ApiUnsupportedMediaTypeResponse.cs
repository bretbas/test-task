using System.Net;

namespace Shared.Infrastructure.ApiResponses;

public class ApiUnsupportedMediaTypeResponse : ApiResponse
{
	public ApiUnsupportedMediaTypeResponse(string message = null)
		: base(HttpStatusCode.UnsupportedMediaType, message)
	{
	}
}