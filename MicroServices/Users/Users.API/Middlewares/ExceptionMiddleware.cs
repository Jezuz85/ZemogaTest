using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Users.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = 400;
                var response = new
                {
                    Message = e.Message
                };
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
    }
}