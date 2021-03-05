using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace FileService.Helpers
{
    public class ErrorResponse
    {
        [JsonProperty("statuscode", DefaultValueHandling = DefaultValueHandling.Ignore, Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int StatusCode { set; get; }
        public string Error { set; get; }
        [JsonProperty("stackTrace", DefaultValueHandling = DefaultValueHandling.Ignore, Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string StackTrace { set; get; }
    }


    /// <summary>
    /// https://code-maze.com/global-error-handling-aspnetcore/
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly IHostEnvironment _hostEnvironment;

        public ErrorHandlingMiddleware(RequestDelegate next,
                                       ILogger<ErrorHandlingMiddleware> logger,
                                       IHostEnvironment hostEnvironment)
        {
            _next = next;
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger, _hostEnvironment);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger<ErrorHandlingMiddleware> logger, IHostEnvironment hostEnvironment)
        {
            int statusCode = GetErrorCode(exception);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var errorResponse = new ErrorResponse()
            {
                StatusCode = statusCode,
                Error = exception.Message
            };

            if (hostEnvironment.IsDevelopment())
            {
                errorResponse.StackTrace = exception.StackTrace;
            }

            logger.LogError(exception.Message);

            return context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }

        private static int GetErrorCode(Exception ex)
        {
            var errorCode = ex switch
            {
                ValidationException _ => HttpStatusCode.BadRequest,
                FormatException _ => HttpStatusCode.BadRequest,
                AuthenticationException _ => HttpStatusCode.Forbidden,
                NotImplementedException _ => HttpStatusCode.NotImplemented,
                _ => HttpStatusCode.InternalServerError
            };

            return (int)errorCode;
        }
    }
}
