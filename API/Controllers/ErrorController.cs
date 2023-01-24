using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("errors/{code}")]
public class ErrorController : ControllerBase
{
    public ActionResult Error(int code)
    {
        return new ObjectResult(new ApiErrorResponse(code));
    }
}
