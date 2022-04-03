using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Shared.Infrastructure.ApiResponses;
using Shared.Infrastructure.ApiResponses.Results;

namespace SomeService1.Controllers.Abstract;

[Route("api/[controller]")]
[ApiController]
public abstract class ApiController : ControllerBase
{
	protected virtual OkObjectResult OkWithMessage(string message) =>
		Ok(new ApiOkResponse(message));

	protected virtual OkObjectResult OkWithResult(object result, string message = null) =>
		Ok(new ApiOkResponse(result, message));

	protected virtual BadRequestObjectResult BadRequestWithMessage(string message, params string[] errors) =>
		BadRequest(new ApiBadRequestResponse(message, errors));

	protected virtual BadRequestObjectResult BadRequestWithMessage(string message, IdentityResult identityResult) =>
		BadRequest(new ApiBadRequestResponse(identityResult, message));

	protected virtual BadRequestObjectResult BadRequestWithMessage(string message, ModelStateDictionary modelState) =>
		BadRequest(new ApiBadRequestResponse(modelState, message));

	protected virtual UnauthorizedObjectResult UnauthorizedWithMessage(string message, params string[] errors) =>
		Unauthorized(new ApiUnauthorizedResponse(message, errors));

	protected virtual UnsupportedMediaTypeObjectResult UnsupportedMediaTypeWithMessage(string message) =>
		new UnsupportedMediaTypeObjectResult(new ApiUnsupportedMediaTypeResponse(message));

	protected virtual PayloadTooLargeObjectResult PayloadTooLargeObjectWithMessage(string message) =>
		new PayloadTooLargeObjectResult(new ApiPayloadTooLargeResponse(message));

	protected virtual ForbidObjectResult ForbidWithMessage(string message) =>
		new ForbidObjectResult(new ApiForbidResponse(message));
}