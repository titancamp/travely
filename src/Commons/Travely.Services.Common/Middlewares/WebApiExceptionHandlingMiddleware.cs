using System;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Travely.Services.Common.CustomExceptions;
using Travely.Services.Common.Models;

namespace Travely.Services.Common.Middlewares
{
    public class WebApiExceptionHandlingMiddleware : ExceptionHandlingMiddleware<WebApiExceptionHandlingMiddleware>
    {
        public WebApiExceptionHandlingMiddleware(RequestDelegate next, ILogger<WebApiExceptionHandlingMiddleware> logger)
            : base(next, logger)
        {
        }

        public override Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode;
            string message;

            switch (exception)
            {
                case BusinessLayerException businessLayerException:
                    statusCode = HttpStatusCode.BadRequest;
                    message = businessLayerException.Message;
                    break;
                default:
                    statusCode = HttpStatusCode.BadRequest;
                    message = $"An error occured while executing the request, please try again later.\n{exception.Message}\n{exception.StackTrace}";
                    break;
            }

            _logger.LogError(message);

            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)statusCode;

            var errorResponse = new ErrorResponse
            {
                Code = (int)statusCode,
                Message = message,
            };

            var errorText = JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });

            return context.Response.WriteAsync(errorText);
        }
    }
}