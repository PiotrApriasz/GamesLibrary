using System.Net;
using GamesLibrary.Shared;

namespace GamesLibrary.API.Middleware;

public class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError, "Something went wrong : ");
        }
    }

    public async Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode statusCode, string message = "")
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsJsonAsync(new BaseResponse()
        {
            Error = true,
            Message = message + exception.StackTrace 
        });
    }
}
