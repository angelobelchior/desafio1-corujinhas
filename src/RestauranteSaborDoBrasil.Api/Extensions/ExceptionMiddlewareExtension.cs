using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace RestauranteSaborDoBrasil.Api.Extensions
{
    public class ExceptionMiddlewareExtension
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddlewareExtension(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext,
                                        ILogger<ExceptionMiddlewareExtension> logger)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(ex, logger);

                throw;
            }
        }

        private static async Task HandleExceptionAsync(Exception exception, ILogger<ExceptionMiddlewareExtension> logger)
        {
            try
            {
                await Task.Run(() => logger.LogError(exception, exception.Message));
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, ex.Message);
            }
        }
    }

}