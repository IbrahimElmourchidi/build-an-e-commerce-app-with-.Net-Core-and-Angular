using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repo;
    public ProductsController(IProductRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
    {
        var products = await _repo.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
    {
        var brands = await _repo.GetAllBrandsAsync();
        return Ok(brands);
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypes()
    {
        var types = await _repo.GetAllTypesAsync();
        return Ok(types);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetSingleProduct(int id)
    {
        return await _repo.GetProductByIdAsync(id);
    }

}
