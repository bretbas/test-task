using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Shared.Infrastructure.ApiResponses.Results;

public class UnsupportedMediaTypeObjectResult : ObjectResult
{
	public UnsupportedMediaTypeObjectResult([ActionResultObjectValue]object error) : base(error)
	{
		StatusCode = (int)HttpStatusCode.UnsupportedMediaType;
	}
}