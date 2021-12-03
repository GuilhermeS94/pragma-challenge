using System;
using System.Net;
using System.Threading.Tasks;
using DotNetCodeChallenge.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DotNetCodeChallenge.Middlewares
{
    public class GlobalExceptionHandler
    {
        private const string JsonContentType = "application/json";
        private readonly RequestDelegate request;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            this.request = next;
        }

        public Task Invoke(HttpContext ctx) => this.InvokeAsync(ctx);

        async Task InvokeAsync(HttpContext ctx)
        {
            try
            {
                await this.request(ctx);
            }
            catch (Exception ex)
            {
                var response = ctx.Response;
                response.ContentType = "application/json";

                switch (ex)
                {

                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonConvert.SerializeObject(new MyGlobalExceptionModel
                {
                    Code = response.StatusCode,
                    Message = ex.Message
                });

                response.ContentType = JsonContentType;

                await response.WriteAsync(result);
            }
        }
    }
}
