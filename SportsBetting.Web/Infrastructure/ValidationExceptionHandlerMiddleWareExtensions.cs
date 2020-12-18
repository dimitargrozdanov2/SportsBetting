using Microsoft.AspNetCore.Builder;

namespace SportsBetting.Web.Infrastructure
{
    public static class ValidationExceptionHandlerMiddleWareExtensions
    {
        public static IApplicationBuilder UseValidationExceptionHandler(this IApplicationBuilder builder)
          => builder.UseMiddleware<ValidationExceptionHandlerMiddleware>();
    }
}
