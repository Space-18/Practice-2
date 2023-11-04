using Biblioteca.Application.Exceptions;
using Biblioteca.Configuration.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Biblioteca.Configuration.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _hostEnvironment;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment hostEnvironment)
        {
            _next = next;
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                httpContext.Response.ContentType = "application/json";
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var result = string.Empty;

                switch (e)
                {
                    case NotFoundException notFoundException:
                        statusCode = (int)HttpStatusCode.NotFound; break;
                    case ValidationException validationException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        var validationJson = JsonSerializer.Serialize(validationException.Errors);


                        var validationErrors = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(validationJson);
                        result = JsonSerializer.Serialize(new CodeErrorException(statusCode, e.Message, validationErrors)); break;


                    //result = JsonSerializer.Serialize(new CodeErrorException(statusCode, e.Message, validationJson)); break;
                    case BadRequestException badRequestException:
                        statusCode = (int)HttpStatusCode.BadRequest; break;
                    default: break;
                }

                if (string.IsNullOrWhiteSpace(result))
                {
                    dynamic response;

                    if (_hostEnvironment.IsDevelopment())
                    {
                        response = new CodeErrorException(statusCode, e.Message, e.StackTrace);
                    }
                    else
                    {
                        response = new CodeErrorResponse(statusCode, e.Message);
                    }

                    var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                    result = JsonSerializer.Serialize(response, options);
                }

                httpContext.Response.StatusCode = statusCode;

                await httpContext.Response.WriteAsync(result);
            }
        }
    }
}
