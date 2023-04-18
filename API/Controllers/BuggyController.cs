using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Errors;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;


public class BuggyController : BaseApiController
{
    private readonly StoreContext _context;
    public BuggyController(StoreContext context)
    {
        _context = context;
    }

    [HttpGet("notfound")]
    public ActionResult GetNotFound()
    {
        var product = _context.Set<Product>().Find(42);
        if (product == null) return NotFound(new ApiErrorResponse(404));
        return Ok(product);
    }

    [HttpGet("servererror")]
    public ActionResult GetServerError()
    {
        var product = _context.Set<Product>().Find(42).ToString();
        if (product == null) return NotFound();
        return Ok(product);

    }

    [HttpGet("badrequest")]
    public ActionResult GetBadRequest()
    {

        return BadRequest(new ApiErrorResponse(400));
    }



    [HttpGet("{id}")]
    public ActionResult GetBadRequestValidation(int id)
    {

        return BadRequest();
    }


}
