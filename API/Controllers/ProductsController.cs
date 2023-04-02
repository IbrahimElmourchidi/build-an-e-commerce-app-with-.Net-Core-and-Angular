using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public string GetProducts()
    {
        return "List of poruducts";
    }

    [HttpGet("{id}")]
    public string GetSingleProduct(int id)
    {
        return $"Product {id}";
    }

}
