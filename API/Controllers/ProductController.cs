using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API.Dtos;
using API.Helpers;
using API.Errors;

namespace API.Controllers;

public class ProductController : BaseApiController
{
    private readonly IGenericRepository<Product> _productRepo;
    private readonly IGenericRepository<ProductType> _productTypeRepo;
    private readonly IGenericRepository<ProductBrand> _productBrandRepo;
    private readonly IMapper _mapper;
    public ProductController(IGenericRepository<Product> productRepo, IGenericRepository<ProductType> productTypeRepo, IGenericRepository<ProductBrand> productBrandRepo,
    IMapper mapper
    )
    {
        _mapper = mapper;
        _productBrandRepo = productBrandRepo;
        _productTypeRepo = productTypeRepo;
        _productRepo = productRepo;

    }
    [HttpGet]
    public async Task<ActionResult<Pagination<ProductToReturn>>> GetAllProducts([FromQuery] ProductSpecParams specParams)
    {
        var spec = new ProductsWithBrandAndTypeSpec(specParams);
        var countSpec = new ProductsWithFiltersCountSpec(specParams);
        var totalItems = await _productRepo.CountAsync(countSpec);
        var products = await _productRepo.ListAllAsyncWithSpec(spec);
        var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturn>>(products);
        // $"{Request.Scheme}://{Request.Host}:{Request.Host.Port ?? 80}"
        var pagination = new Pagination<ProductToReturn>(specParams)
        {
            Data = data,
            Count = totalItems,
            BaseUrl = $"{Request.Scheme}://{Request.Host}/api/product?"
        };
        return Ok(pagination);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetAllBrands()
    {
        var brands = await _productBrandRepo.ListAllAsync();
        return Ok(brands);
    }

    [HttpGet("Types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetAllTypes()
    {
        var types = await _productTypeRepo.ListAllAsync();
        return Ok(types);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductToReturn>> GetSingleProduct(int id)
    {
        var spec = new ProductsWithBrandAndTypeSpec(id);
        var product = await _productRepo.GetSingleWithSpec(spec);
        if (product == null) return NotFound(new ApiErrorResponse(404));
        var productToReturn = _mapper.Map<Product, ProductToReturn>(product);
        return Ok(productToReturn);
    }
}
