using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Errors;

public class ApiValidationErrorResponse : ApiErrorResponse
{
    public ApiValidationErrorResponse() : base(400)
    {
    }
    public IEnumerable<string> Errors { get; set; }
}
