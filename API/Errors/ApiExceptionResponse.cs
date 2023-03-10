using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors;

public class ApiExceptionResponse : ApiErrorResponse
{
    public ApiExceptionResponse(int statusCode, string? message = null, string? details = null) : base(statusCode, message)
    {
        Details = details;
        StatusCode = statusCode;
        Message = message;

    }

    public string? Details { get; set; }
}
