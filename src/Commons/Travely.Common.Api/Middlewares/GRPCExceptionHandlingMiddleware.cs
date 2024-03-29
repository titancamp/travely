using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Travely.Common.CustomExceptions;

namespace Travely.Common.Api.Middlewares
{
    public class GRPCExceptionHandlingMiddleware : ExceptionHandlingMiddleware<GRPCExceptionHandlingMiddleware>
    {
        public GRPCExceptionHandlingMiddleware(RequestDelegate next, ILogger<GRPCExceptionHandlingMiddleware> logger)
            : base(next, logger)
        {
        }

        public override Task HandleExceptionAsync(HttpContext context, Exception exception)
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