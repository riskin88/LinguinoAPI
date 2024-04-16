using BLL.Config;
using Microsoft.Extensions.Options;

public class SwaggerAuthorizedMiddleware
{
    private readonly RequestDelegate _next;
    private readonly SwaggerSettings _configuration;

    public SwaggerAuthorizedMiddleware(RequestDelegate next, IOptions<SwaggerSettings> configuration)
    {
        _next = next;
        _configuration = configuration.Value;
    }

    public async Task InvokeAsync(HttpContext context)
    {

        if (context.Request.Path.StartsWithSegments("/swagger"))
        {
            if (context.Request.QueryString.Value.Contains("key=" + _configuration.Key))
                await _next.Invoke(context);
            else
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }
        }

    }
}