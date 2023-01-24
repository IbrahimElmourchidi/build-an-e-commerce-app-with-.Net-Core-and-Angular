using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class BuggyController : BaseApiController
{
    private readonly StoreContext _context;
    public BuggyController(StoreContext context)
    {
        _context = context;
    }

    [HttpGet("notfound")]
    public async Task<ActionResult<Product>> GetNotFound()
    {
        var product = await _context.Products.FindAsync(42);
        if (product == null) return NotFound(new ApiErrorResponse(404));
        return Ok(product);
    }

    [HttpGet("servererror")]
    public async Task<ActionResult<string>> GetServerError()
    {
        var product = await _context.Products.FindAsync(43);
        var productToReturn = product.ToString();
        return Ok(productToReturn);
    }

    [HttpGet("badrequest")]
    public async Task<ActionResult<Product>> GetBadRequest()
    {
        return BadRequest(new ApiErrorResponse(400));
    }

    [HttpGet("badrequest/{id}")]
    public async Task<ActionResult<Product>> GetBadRequestValidation(int id)
    {
        return BadRequest();
    }

}
