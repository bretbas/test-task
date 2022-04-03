using Microsoft.AspNetCore.Http;
using Shared.Additions.Extensions;
using Shared.Infrastructure.ApiResponses;

namespace Shared.Middlewares;

public class ExceptionMiddleware
{
	private readonly RequestDelegate _next;

	public ExceptionMiddleware(RequestDelegate next)
	{
		_next = next ?? throw new ArgumentNullException(nameof(next));
	}

	public async Task InvokeAsync(HttpContext httpContext)
	{
		try
		{
			await _next(httpContext);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(httpContext, ex);
		}
	}

	private Task HandleExceptionAsync(HttpContext context, Exception exception)
	{
		ApiResponse response = ToApiResponse((dynamic)exception, context);

		context.Response.ContentType = "application/json";
		context.Response.StatusCode = response.StatusCode;
		return context.Response.WriteAsync(response.ToJson());
	}

	private ApiResponse ToApiResponse(NotFoundException ex, HttpContext context) =>
		new ApiNotFoundResponse(ex.Message);

	private ApiResponse ToApiResponse(AccessException ex, HttpContext context) =>
		new ApiForbidResponse(ex.Message);

	private ApiResponse ToApiResponse(ConflictException ex, HttpContext context) =>
		new ApiBadRequestResponse(ex.Message);

	private ApiResponse ToApiResponse(Exception ex, HttpContext context)
	{
		// TODO Тут можно что-то залогировать
		return new ApiInternalServerErrorResponse("Server internal error");
	}
}