using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Web
{
    public class AppExceptionMiddleware
    {
        readonly RequestDelegate next;
        const int ERR_CONSTRAINT = 547;
        const int ERR_UNIQUE = 2601;
        const int ERR_DUPLICATE = 2627;
        const int ERR_CONCURRENCY = 50000;
        const int ERR_WITH_MESSAGE = 50001;

        public AppExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<object> logger)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, logger);
            }
        }

        static async Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger logger)
        {
            int statusCode;
            var result = JsonConvert.SerializeObject(new { Message = "Unexpected Error" });

            if (exception is BaseApp.Common.SecurityException)
            {
                statusCode = (int)HttpStatusCode.Forbidden;
                result = JsonConvert.SerializeObject(new
                {
                    hasError = true,
                    status = statusCode,
                    message = "Authorization has been denied for this request."
                });
            }
            else
            {
                var logExceptionDetails = true;
                var message = exception.Message;
                string correlationId = null;
                int? code = null;
                string kind = null;

                if (exception is BaseApp.Common.ValidationException)
                {
                    kind = "Validation";
                    logExceptionDetails = false;
                }
                else if (exception is System.Data.SqlClient.SqlException)
                {
                    var sqlException = exception as System.Data.SqlClient.SqlException;
                    kind = "SQL";
                    code = sqlException.Number;
                    correlationId = Guid.NewGuid().ToString().Replace("-", "");
                    switch (code)
                    {
                        case ERR_CONSTRAINT:
                            if (sqlException.Procedure.EndsWith("_Delete", StringComparison.InvariantCultureIgnoreCase))
                            {
                                message = "This record cannot be deleted because some related data is referring to it.";
                                logExceptionDetails = false;
                            }
                            else
                            {
                                message = $"The operation failed with code {code}. Correlation ID is [{correlationId}]";
                            }
                            break;
                        case ERR_UNIQUE:
                        case ERR_DUPLICATE:
                            message = "A record with the same key already exists.";
                            logExceptionDetails = false;
                            break;
                        case ERR_CONCURRENCY:
                            message = "The data was modified by another user. You need to refresh the screen to continue - your changes will be lost.";
                            logExceptionDetails = false;
                            break;
                        case ERR_WITH_MESSAGE:
                            logExceptionDetails = false;
                            break;
                        default:
                            message = $"The operation failed with code {code}. Correlation ID is [{correlationId}]";
                            break;
                    }
                }
                else
                {
                    kind = "Api";
                    code = 0;
                    correlationId = Guid.NewGuid().ToString().Replace("-", "");
                    message = $"The operation failed with correlation ID [{correlationId}]";
                }

                if (logExceptionDetails)
                {
                    var bodyText = "";
                    var body = context.Request.Body;
                    body.Position = 0;

                    using (var reader = new StreamReader(body, Encoding.UTF8, true, 4096, true))
                    {
                        bodyText = await reader.ReadToEndAsync();
                    }

                    if (string.IsNullOrEmpty(correlationId))
                        logger.LogError("Code={0}, URL={1} BODY={2}\n{3}", code, context.Request.Path, bodyText, exception);
                    else
                        logger.LogError("CORRELATIONID=[{0}], CODE={1}, URL={2} BODY={3}\n{4}", correlationId, code, context.Request.Path, bodyText, exception);
                }
                else
                {
                    logger.LogInformation(exception.Message);
                }

                statusCode = (int)HttpStatusCode.InternalServerError;
                result = JsonConvert.SerializeObject(new
                {
                    hasError = true,
                    status = statusCode,
                    message,
                    kind,
                    code,
                });
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(result);
        }
    }

    public static class RequestResponseLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder Use_AppExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AppExceptionMiddleware>();
        }
    }
}
