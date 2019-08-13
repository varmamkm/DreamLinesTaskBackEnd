using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using Serilog;

namespace DL.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            const HttpStatusCode code = HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(new { error = $"Internal Api Error: {exception.GetBaseException().Message}" });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            Log.Error(exception.StackTrace);
            return context.Response.WriteAsync(result);
        }
    }
}
