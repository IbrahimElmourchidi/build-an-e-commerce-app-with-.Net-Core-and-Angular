using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;

namespace API.Middlewares;

public class ApiExceptionMiddleware
{
    private readonly ILogger<ApiExceptionMiddleware> _logger;
    private readonly RequestDelegate _next;
    private readonly IHostEnvironment _env;
    public ApiExceptionMiddleware(RequestDelegate next, IHostEnvironment env, ILogger<ApiExceptionMiddleware> logger)
    {
        _env = env;
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (System.Exception ex)
        {
            var statuCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statuCode;

            var response = _env.IsDevelopment() ?
            new ApiExceptionResponse(statuCode, ex.Message, ex.StackTrace) :
            new ApiExceptionResponse(statuCode);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            var jsonResponse = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(jsonResponse);

        }
    }
}
