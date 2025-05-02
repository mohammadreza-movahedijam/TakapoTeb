using Application.Common.CustomException;
using Application.Common.Resource;
using System.Text.Json;

namespace WebUI.Middlewares;

public class ExceptionLoggingMiddleware
{
    readonly RequestDelegate? _next;
    readonly ILogger<ExceptionLoggingMiddleware>? _logger;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="next"></param>
    /// <param name="logger"></param>
    public ExceptionLoggingMiddleware(RequestDelegate next,
        ILogger<ExceptionLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next!(context);
        }
        catch (System.Exception ex)
        {
            _logger!.LogError(ex, ex.Message, context.Request.Path);

            context.Response.Redirect("/error");

        }
    }
}