using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Threading.Tasks;
using WMS.Contracts;

namespace WMS.LoggerService
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILoggerManager>();
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    await HandleExceptionAsync(context, ex, logger);
                }
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, ILoggerManager logger)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorMessage = exception.Message + (exception.InnerException != null ? " | Inner Exception: " + exception.InnerException.Message : "");
            var controllerName = context.Request.RouteValues["controller"]?.ToString() ?? "Unknown";
            var actionName = context.Request.RouteValues["action"]?.ToString() ?? "Unknown";
            var ipAddress = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
            var userId = context.User.Identity.IsAuthenticated ? int.Parse(context.User.FindFirst("sub")?.Value ?? "0") : (int?)null;

            await logger.LogExceptionAsync(errorMessage, controllerName, actionName, ipAddress, userId);

            await context.Response.WriteAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = "An unexpected error occurred. Please try again later."
            }.ToString());
        }
    }
}