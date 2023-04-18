using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Errors;

public class ApiErrorResponse
{
    public ApiErrorResponse(int statusCode, string message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageForCode(statusCode);
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }

    private string GetDefaultMessageForCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "Bad Request",
            401 => "Un Authorized",
            404 => "Resource Not Found",
            500 => "Internal Server Error",
            _ => null
        };
    }
}
