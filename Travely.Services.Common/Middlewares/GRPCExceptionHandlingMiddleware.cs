using System;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Travely.Services.Common.CustomExceptions;

namespace Travely.Services.Common.Middlewares
{
	public class GRPCExceptionHandlingMiddleware  : ExceptionHandlingMiddleware<GRPCExceptionHandlingMiddleware>
	{
		public GRPCExceptionHandlingMiddleware(RequestDelegate next, ILogger<GRPCExceptionHandlingMiddleware> logger)
			: base(next, logger)
		{
		}

		public Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			var statusCode = StatusCode.Internal;
			var message = string.Empty;

			switch (exception)
			{
				case NotFoundException notFoundException:
					statusCode = StatusCode.NotFound;
					message = notFoundException.Message;
					break;
				case InvalidArgumentException invalidArgumentException:
					statusCode = StatusCode.InvalidArgument;
					message = invalidArgumentException.Message;
					break;
				default:
					statusCode = StatusCode.Internal;
					message = "Internal server error.";
					break;
			}

			_logger.LogError(message);
			throw new RpcException(new Status(statusCode, message));
		}
	}
}