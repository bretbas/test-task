using System.Net;

namespace Shared.Infrastructure.ApiResponses;

public class ApiOkResponse : ApiResponse
{
	public object Result { get; set; }

	public ApiOkResponse() : base(HttpStatusCode.OK, null)
	{
	}

	public ApiOkResponse(string message = null) : base(HttpStatusCode.OK, message)
	{
	}

	public ApiOkResponse(object result, string message = null) : base(HttpStatusCode.OK, message)
	{
		Result = result;
	}
}

public class ApiOkResponse<T> : ApiResponse
{
	public T Result { get; set; }

	public ApiOkResponse() : base(HttpStatusCode.OK, null)
	{
	}

	public ApiOkResponse(string message = null) : base(HttpStatusCode.OK, message)
	{
	}

	public ApiOkResponse(T result, string message = null) : base(HttpStatusCode.OK, message)
	{
		Result = result;
	}
}