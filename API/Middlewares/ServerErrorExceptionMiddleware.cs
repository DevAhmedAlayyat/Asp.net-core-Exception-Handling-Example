using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace API.Middlewares
{
    public class ServerErrorExceptionMiddleware
    {
        private readonly RequestDelegate _reqDelegate;
        private readonly ILogger<ServerErrorExceptionMiddleware> _logger;
        public ServerErrorExceptionMiddleware(
            RequestDelegate reqDelegate,
            ILogger<ServerErrorExceptionMiddleware> logger
        )
        {
            _reqDelegate = reqDelegate;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try 
            {
                await _reqDelegate(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                var serializerOptions = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var errorMessage = JsonSerializer.Serialize(
                        new ApiExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.ToString()),
                        serializerOptions
                    );
                
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsync(errorMessage);
            }
        }
}
}