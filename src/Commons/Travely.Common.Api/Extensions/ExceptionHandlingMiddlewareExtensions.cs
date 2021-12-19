using Microsoft.AspNetCore.Builder;
using Travely.Common.Api.Middlewares;

namespace Travely.Common.Api.Extensions
{
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseGRPCExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GRPCExceptionHandlingMiddleware>();
        }

        public static IApplicationBuilder UseWebApiExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WebApiExceptionHandlingMiddleware>();
        }
    }
}
