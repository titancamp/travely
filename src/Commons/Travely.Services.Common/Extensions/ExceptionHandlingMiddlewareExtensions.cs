using Microsoft.AspNetCore.Builder;

using Travely.Services.Common.Middlewares;

namespace Travely.Services.Common.Extensions
{
	public static class ExceptionHandlingMiddlewareExtensions
	{
		public static IApplicationBuilder UseGRPCExceptionHandler(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<GRPCExceptionHandlingMiddleware>();
		}
	}
}
