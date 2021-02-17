using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Travely.Services.Common.Middlewares
{
	public abstract class ExceptionHandlingMiddleware<T>
	{
		protected readonly RequestDelegate _next;
		protected readonly ILogger<T> _logger;

		protected ExceptionHandlingMiddleware(RequestDelegate next, ILogger<T> logger)
		{
			_next = next ?? throw new ArgumentNullException(nameof(next));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		public abstract Task HandleExceptionAsync(HttpContext context, Exception exception);
	}
}
