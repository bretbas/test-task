using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Shared.Additions.Extensions;

namespace Shared.Infrastructure.ApiResponses;

public class ApiBadRequestResponse : ApiResponse
{
	public IEnumerable<string> Errors { get; }

	public ApiBadRequestResponse(ModelStateDictionary modelState, string message = null)
		: base(HttpStatusCode.BadRequest, message)
	{
		if(modelState == null) throw new ArgumentNullException(nameof(modelState));
		if (modelState.IsValid) throw new ArgumentException("ModelState must be invalid", nameof(modelState));

		Errors = modelState.ToList();
	}

	public ApiBadRequestResponse(IdentityResult identityResult, string message = null)
		: base(HttpStatusCode.BadRequest, message)
	{
		if (identityResult == null) throw new ArgumentNullException(nameof(identityResult));
		if (identityResult.Succeeded) throw new ArgumentException("Identity result must be invalid", nameof(identityResult));

		Errors = identityResult.Errors.Select(x => x.Description);
	}

	public ApiBadRequestResponse(string message, params string[] errors)
		: base(HttpStatusCode.BadRequest, message)
	{
		Errors = errors.Any() ? errors : null;
	}
}