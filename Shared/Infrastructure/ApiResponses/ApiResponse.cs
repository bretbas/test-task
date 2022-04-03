using System.Net;

namespace Shared.Infrastructure.ApiResponses;

public class ApiResponse
{
	public string Message { get; }

	public bool Success => (StatusCode >= 200) && (StatusCode <= 299);

	public int StatusCode { get; }

	public ApiResponse(HttpStatusCode code, string message = null)
	{
		StatusCode = (int)code;
		Message = message;
	}
}