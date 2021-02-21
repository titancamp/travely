using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace FileService.Helpers
{
    public class ErrorResponse
    {
        [JsonProperty("code", DefaultValueHandling = DefaultValueHandling.Ignore, Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Code { set; get; }
        public string Error { set; get; }
        [JsonProperty("stackTrace", DefaultValueHandling = DefaultValueHandling.Ignore, Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string StackTrace { set; get; }
    }

    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger _logger;
        public ErrorHandlingMiddleware(RequestDelegate next,
                                       ILogger<ErrorHandlingMiddleware> logger)
        {
            this.next = next;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, this._logger);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger logger)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            string result = null;
            if (exception is RESTException)
            {
                var restEx = exception as RESTException;
                var er = new ErrorResponse { Error = restEx.Message };
                code = restEx.StatusCode;
                if (!string.IsNullOrEmpty(restEx.Code))
                {
                    er.Code = restEx.Code;
                }

                result = JsonConvert.SerializeObject(er);
                if ((int)code >= 500)
                {
                    logger.LogError(restEx.Message);
                }
                else
                {
                    logger.LogDebug(restEx.Message);
                }
            }
            else
            {
                var er = new ErrorResponse { Error = exception.Message };

                result = JsonConvert.SerializeObject(er);
                logger.LogError(exception, "");
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
