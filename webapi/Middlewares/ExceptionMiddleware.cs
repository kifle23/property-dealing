using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using webapi.Errors;

namespace webapi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        public ILogger<ExceptionMiddleware> logger { get; }
        public IHostEnvironment env { get; }

        public ExceptionMiddleware(RequestDelegate next,
        ILogger<ExceptionMiddleware> logger,
        IHostEnvironment env)
        {
            this.env = env;
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                APIError response;
                int statusCode = (int)HttpStatusCode.InternalServerError;
                if (env.IsDevelopment())
                {
                    response = new APIError((int)statusCode, ex.Message, ex.StackTrace?.ToString());
                }
                else
                {
                    response = new APIError(statusCode, ex.Message);
                }
                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = statusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response.ToString());
            }
        }
    }
}